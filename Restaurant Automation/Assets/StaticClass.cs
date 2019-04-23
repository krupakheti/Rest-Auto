using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticClass : MonoBehaviour {
     public int LoginNumber;

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    

    public void setLogin(int employeeType) { 
        while (employeeType >= 10)employeeType /= 10;    
        LoginNumber = employeeType;    
    }

    public int getLogin() { 
        return LoginNumber;    
    }

    public void terminateAll() {
        StaticClass[] allSC = GameObject.FindObjectsOfType<StaticClass>();
        foreach(StaticClass currentSC in allSC) currentSC.selfTerminate();        
    }

    public void selfTerminate() { Destroy(this.gameObject);}
}
