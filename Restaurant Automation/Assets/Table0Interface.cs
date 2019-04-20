using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table0Interface : MonoBehaviour
{
    public Button m_YourTable0;
    public int userID;

    // Use this for initialization
    void Start()
    {
        m_YourTable0.onClick.AddListener(DiffTable0Interface);

    }

    void DiffTable0Interface()
    {
        int firstdigit = Convert.ToInt32(userID.ToString().Substring(0, 1));
        if (firstdigit == 1)
        {
            Debug.Log("Go to host interface");
            //HostInterfaceClass
        }
        if (firstdigit == 2)
        {
            Debug.Log("Go to waiter interface");
            //WaiterInterfaceClass
        }
        if (firstdigit == 3)
        {
            Debug.Log("Go to busser interface");
            //BusserInterfaceClass
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
