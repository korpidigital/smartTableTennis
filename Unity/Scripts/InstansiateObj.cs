using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstansiateObj : MonoBehaviour
{
    public GameObject myPrefabObjec = null;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(motion2.hit == 1)
        {
            Instantiate(myPrefabObjec, transform.position, Quaternion.identity);
        

        }
    }
}
