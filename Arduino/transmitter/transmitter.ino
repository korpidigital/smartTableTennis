#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>
#include <ESP8266WiFi.h>
#include <Wire.h>

//create wifi credecials
const char *ssid = "test";
const char *password = "12345678";


// Check I2C device address and correct line below (by default address is 0x29 or 0x28)
//                                   id, address
Adafruit_BNO055 bno = Adafruit_BNO055(-1, 0x28);

const int analogInPin = A0;  // ESP8266 Analog Pin ADC0 = A0




String sensorValue0 = "";       
String sensorValue1 = "";        
String sensorValue2 = "";        
String sensorValue3 = "";       
String sensorValue4 = "";       
String sensorValue5 = "";        
String sensorValue6 = "";   
String sensorValue7 = "";   
  

void setup() {
  Wire.setClock(40000);
  Serial.begin(115200);

  bno.begin();
  bno.setExtCrystalUse(true);
  
// set the ESP8266 to be a WiFi-client
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  vibra();

}


void loop() {


//wifi
 // Use WiFiClient class to create TCP connections
  WiFiClient client;
  const char * host = "192.168.4.1";            //default IP address
  const int httpPort = 80;

 
  if (!client.connect(host, httpPort)) {
    Serial.println("connection failed");
    return;   
  }


  imu::Quaternion quat = bno.getQuat();
  uint8_t system, gyro, accel, mag = 0;
  bno.getCalibration(&system, &gyro, &accel, &mag);


  //_________Quaterion_____________________
  sensorValue0 = String(quat.w(), 2);
  sensorValue1 = String(quat.x(), 2);    
  sensorValue2 = String(quat.y(), 2);
  sensorValue3 = String(quat.z(), 2);
   //_________Calibration____________________
  sensorValue4 = String(system, DEC);  
  sensorValue5 = String(gyro, DEC);      
  sensorValue6 = String(accel, DEC);
  sensorValue7 = String(mag, DEC);
  //__________Hit___________________________


  
  
  // We now create a URI for the request. Something like /data/?sensor_reading=123
  String url = "/data/";
  url += "?sensor_reading=";
  url +=  "{\"sensor0_reading\":\"sensor0_value\",\"sensor1_reading\":\"sensor1_value\","
        "\"sensor2_reading\":\"sensor2_value\",\"sensor3_reading\":\"sensor3_value\","
        "\"sensor4_reading\":\"sensor4_value\",\"sensor5_reading\":\"sensor5_value\","
        "\"sensor6_reading\":\"sensor6_value\",\"sensor7_reading\":\"sensor7_value\"}";
  url.replace("sensor0_value", sensorValue0);
  url.replace("sensor1_value", sensorValue1);
  url.replace("sensor2_value", sensorValue2);
  url.replace("sensor3_value", sensorValue3);
  url.replace("sensor4_value", sensorValue4);
  url.replace("sensor5_value", sensorValue5);
  url.replace("sensor6_value", sensorValue6);
  url.replace("sensor7_value", sensorValue7);


   // This will send the request to the server
  client.print(String("GET ") + url + " HTTP/1.1\r\n" +
               "Host: " + host + "\r\n" +
               "Connection: close\r\n\r\n");
               
 // Serial.print(url+"\n");
 

}


void vibra(){
  pinMode(14, OUTPUT);    // sets the digital pin 13 as output

  for(int a = 0; a < 4; a = a + 1 ){
    digitalWrite(14, HIGH); // sets the digital pin 13 on
    delay(250);            // waits for a second
    digitalWrite(14, LOW);  // sets the digital pin 13 off
    delay(250);            // waits for a secondm
  }
}
