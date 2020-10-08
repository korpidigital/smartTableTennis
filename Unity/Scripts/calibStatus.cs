using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class calibStatus : MonoBehaviour
{
    
    
    public Text calibText;


    // Update is called once per frame
    void Update()
    {
        calibText.text = "Fully calibrated = 3 \n" +
                        "System: " + motion2.calibSystem.ToString() + "\n" +
                        "Gyroscope: " + motion2.calibGyro.ToString() + "\n" +
                        "Accelerometer: " + motion2.calibAcc.ToString() + "\n" +
                        "Magnetometer: " + motion2.calibMag.ToString();
    }
}
