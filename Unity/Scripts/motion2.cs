
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;
using System;




public class motion2 : MonoBehaviour

{

    public static float w, x, y, z, wNorm, xNorm, yNorm, zNorm, xAngle, yAngle, zAngle;
    public static double accX0, accX1; 
    public static int calibSystem, calibGyro, calibAcc, calibMag, hit;
    string UnSplitData = "0|0|0|0|0|0|0|0";
    string[] SplitData = new string[8];
    public static string wStr, xStr, yStr, zStr;
    

    public GameObject tableObj = null;







    void Start()
    {

         

    }

    void Update()
    {

        

        UnSplitData = comPort.sp.ReadLine();


        SplitData = UnSplitData.Split('|');
        //print(UnSplitData);
        readQuaternions(SplitData);
        readCalibrationStatus(SplitData);
        //readHitStatus(SplitData);
        //readAcceleration(SplitData);
        paddleAngle();
        




        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }



    }

    

    public void readQuaternions(string[] splitData)
    {
        wStr = SplitData[0];
        xStr = SplitData[1];
        yStr = SplitData[2];
        zStr = SplitData[3];

        w = float.Parse(wStr);
        x = float.Parse(xStr);
        y = float.Parse(yStr);
        z = float.Parse(zStr);

        //normalize quaterions

        float factor = Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f) + Mathf.Pow(z, 2f) + Mathf.Pow(w, 2f));
        xNorm = x / factor;
        yNorm = y / factor;
        zNorm = z / factor;
        wNorm = w / factor;

        //When tinkering orientation make sure to have physical IC right way
        //Quaternion(x,y,z,w) should be the order? But (x,z,y,w) works mirrored, so inverse is done :
        Quaternion reverse = new Quaternion(xNorm, zNorm, yNorm, wNorm);

        //Racket rotation with quaternions
        transform.rotation = Quaternion.Inverse(reverse);
    }

    public void readCalibrationStatus(string[] splitData)
    {
        

        calibSystem = Int32.Parse(SplitData[4]);
        calibGyro = Int32.Parse(SplitData[5]);
        calibAcc = Int32.Parse(SplitData[6]);
        calibMag = Int32.Parse(SplitData[7]);

    }

    //public void readHitStatus(string[] splitData)
    //{
    //    hit = Int32.Parse(SplitData[8]);
    //    if(hit == 1)
    //    {
    //        print(hit);
            

    //    }
               
    //}

    //public void readAcceleration(string[] splitData)
    //{
    //    accX0 = double.Parse(SplitData[9]);
    //    accX1 = double.Parse(SplitData[10]);
    //}

    public void paddleAngle()
    {


        xAngle = Convert.ToInt32(gameObject.transform.localEulerAngles.x);
        yAngle = Convert.ToInt32(gameObject.transform.localEulerAngles.y);
        zAngle = Convert.ToInt32(gameObject.transform.localEulerAngles.z);


    }




}