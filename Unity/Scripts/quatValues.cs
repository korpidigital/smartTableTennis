using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class quatValues : MonoBehaviour
{
    //motion2 motion = new motion2();
    
    public Text quatText;
    

    // Update is called once per frame
    void Update()
    {
        quatText.text = "Quaternion x: " + motion2.x.ToString() + "\n" +
                        "Quaternion y: " + motion2.y.ToString() + "\n" +
                        "Quaternion z: " + motion2.z.ToString() + "\n" +
                        "Quaternion w: " + motion2.w.ToString() ;
    }
}
