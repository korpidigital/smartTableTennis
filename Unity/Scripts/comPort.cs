using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class comPort : MonoBehaviour
    
{

    List<String> ports = new List<string>();
    public Dropdown dropdown;
    private string selectedCom;
    public static SerialPort sp;// = new SerialPort("COM3", 115200);

    void Start()
    {

        populateList();
        selectedCom = ports[0];

        sp = new SerialPort(selectedCom, 115200);
        sp.Open();
        sp.ReadTimeout = 5000;

        dropdown.onValueChanged.AddListener(delegate {
            dropdownIndexChange(dropdown.value);
        });

    }
    public void dropdownIndexChange(int index)
    {
        sp.Close();
        selectedCom = ports[index];
        sp = new SerialPort(selectedCom, 115200);
        sp.Open();
        print(selectedCom);
        sp.ReadTimeout = 5000;

    }


    void populateList()
        
    {
        
        foreach (string port in SerialPort.GetPortNames())
        {
            ports.Add(port);
        }
        
        dropdown.AddOptions(ports);
        
    }

}
