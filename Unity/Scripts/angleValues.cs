using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class angleValues : MonoBehaviour
{
    

    public Text angleText;


    // Update is called once per frame
    void Update()
    {
        angleText.text = "x-angle: " + motion2.xAngle.ToString() + "\n" +
                        "y-angle: " + motion2.yAngle.ToString() + "\n" +
                        "z-angle: " + motion2.zAngle.ToString();
                        
    }
}
