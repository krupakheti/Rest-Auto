using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticClass : MonoBehaviour {
     public static int LoginNumber { get; set; }

    public void setLogin(int employeeType) { 
        while (employeeType >= 10)employeeType /= 10;    
        LoginNumber = employeeType;    
    }
}
