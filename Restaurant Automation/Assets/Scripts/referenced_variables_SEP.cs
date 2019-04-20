using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class referenced_variables_SEP : MonoBehaviour {

	public static string UID = "";
	public static int privilage_type = 0;//0 = none, 1 = host, 2 = wait staff, 3 = busser, 4 = chef, 5 = admin
	public static int login_sucessful = 0;//0 = false, 1 = true.
	public static List<string> UID_list = new List<string>(new string[] {"11490","21170","30890","46660","53140"});


	// Use this for initialization
	void Start () {
		//Why doen't the below happen?
		/*
		UID_list.Add ("11490");
		UID_list.Add ("21170");
		UID_list.Add ("30890");
		UID_list.Add ("46660");
		UID_list.Add ("53140");
		*/
	}

}
