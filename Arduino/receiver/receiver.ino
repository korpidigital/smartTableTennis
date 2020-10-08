

#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include <ArduinoJson.h>

DynamicJsonBuffer jsonBuffer;

const char *ssid      = "test";
const char *password  = "12345678";

float sensorValue0,sensorValue1,sensorValue2,sensorValue3,sensorValue4,sensorValue5,sensorValue6,sensorValue7;         
String sensor_values;

ESP8266WebServer server(80);

void handleSentVar() {

  if (server.hasArg("sensor_reading"))
  {
    sensor_values = server.arg("sensor_reading");
//    Serial.println(sensor_values);
  }
  JsonObject& root = jsonBuffer.parseObject(sensor_values);
//  if (!root.success()) {
//    Serial.println("parseObject() failed");
//    return;
//  }
//  if (root.success())
//  {
  sensorValue0          = root["sensor0_reading"].as<float>();
  sensorValue1          = root["sensor1_reading"].as<float>();
  sensorValue2          = root["sensor2_reading"].as<float>();
  sensorValue3          = root["sensor3_reading"].as<float>();
  sensorValue4          = root["sensor4_reading"].as<float>();    
  sensorValue5          = root["sensor5_reading"].as<float>();        
  sensorValue6          = root["sensor6_reading"].as<float>(); 
  sensorValue7          = root["sensor7_reading"].as<float>();
  sensorValue8          = root["sensor8_reading"].as<float>();

//  }


  // Print the values on the serial monitor
  String Sentence = String(sensorValue0);
  Sentence += "|" + String(sensorValue1);
  Sentence += "|" + String(sensorValue2);
  Sentence += "|" + String(sensorValue3);
  Sentence += "|" + String((int)sensorValue4);
  Sentence += "|" + String((int)sensorValue5);
  Sentence += "|" + String((int)sensorValue6);
  Sentence += "|" + String((int)sensorValue7);
  Serial.println(Sentence);
  jsonBuffer.clear();
  Serial.flush();

}


void setup() {
  Serial.begin(115200);
  WiFi.softAP(ssid, password);
  IPAddress myIP = WiFi.softAPIP();

  server.on("/data/", HTTP_GET, handleSentVar); // when the server receives a request with /data/ in the string then run the handleSentVar function
  server.begin();
}

void loop() {
  server.handleClient();
 
}
