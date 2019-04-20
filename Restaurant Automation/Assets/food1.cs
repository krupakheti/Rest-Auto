using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



public class food1 : MonoBehaviour {

    public string pathtofood;







void Start()
{
    pathtofood = "Assets/food.csv";

    get_order_info();



    Debug.Log(Application.persistentDataPath);
}



public void get_order_info()
{



    //read in the current target file's data--\/

    StreamReader reader = new StreamReader(pathtofood, true);//create "stream reader" from current file.
    string string_from_file = reader.ReadToEnd();
    var nextLine = reader.ReadLine();
    string nextline1 = reader.ReadToEnd();




        //get the raw text of the file
        reader.Close();//close the "stream reader"

    Debug.Log(string_from_file);
}
}

