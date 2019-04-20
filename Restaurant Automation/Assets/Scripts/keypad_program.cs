using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad_program : MonoBehaviour {



	//number buttons--\/

	public void buttonCLick_0()
	{
		add_to_UID(0);
	}
	public void buttonCLick_1()
	{
		add_to_UID(1);
	}
	public void buttonCLick_2()
	{
		add_to_UID(2);
	}
	public void buttonCLick_3()
	{
		add_to_UID(3);
	}
	public void buttonCLick_4()
	{
		add_to_UID(4);
	}
	public void buttonCLick_5()
	{
		add_to_UID(5);
	}
	public void buttonCLick_6()
	{
		add_to_UID(6);
	}
	public void buttonCLick_7()
	{
		add_to_UID(7);
	}
	public void buttonCLick_8()
	{
		add_to_UID(8);
	}
	public void buttonCLick_9()
	{
		add_to_UID(9);
	}

	//number buttons--/\



	//used to move to another scene--\/

	private void load_scene(int scene_number) {
		SceneManager.LoadScene(scene_number);
	}

	//used to move to another scene--/\



	//appends to UID, up to 5 numbers--\/

	private void add_to_UID(int key_value){

		string temp_string = referenced_variables_SEP.UID;
		if (temp_string.Length < 5) {
			temp_string = temp_string + key_value.ToString ();
			referenced_variables_SEP.UID = temp_string;
			Debug.Log ("UID = " + referenced_variables_SEP.UID);
		} else {
			Debug.Log ("UID already has 5 numbers in it, clearing.");
			clear_UID ();
			temp_string = "";
			temp_string = temp_string + key_value.ToString ();
			referenced_variables_SEP.UID = temp_string;
			Debug.Log ("UID = " + referenced_variables_SEP.UID);
		}

	}

	//appends to UID, up to 5 numbers--/\



	//attempt to login--\/

	public void attempt_login(){

		string UID = referenced_variables_SEP.UID;
		List<string> UID_list = referenced_variables_SEP.UID_list;
		Debug.Log ("UID_list>");
		Debug.Log (UID_list);
		bool match = false;
		Debug.Log ("about to enter foreach loop");
		foreach (string stored_UID in UID_list) {
			Debug.Log ("test");
			Debug.Log ("Checking if " + stored_UID + " = " + UID);
			if (stored_UID == UID) {
				match = true;
				referenced_variables_SEP.login_sucessful = 1;
				var UID_CA = UID.ToCharArray();
				referenced_variables_SEP.privilage_type = (UID_CA[0] - '0');//https://stackoverflow.com/questions/239103/convert-char-to-int-in-c-sharp
				Debug.Log ("Login sucessful. Privilage type =" + UID_CA[0]);
				//load_scene(1);
			}
		}
		if (match == false) {
			Debug.Log ("Login unsucessful");
			clear_UID ();
		}

	}

	//attempt to login--/\



	//clear the UID--\/

	public void clear_UID(){

		referenced_variables_SEP.UID = "";
		Debug.Log ("UID cleared");

	}

	//clear the UID--/\



}
