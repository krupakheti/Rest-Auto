using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KS_program : MonoBehaviour {

	public int order_up_to_x_fulfilled;//Why couldn't I set the value to 1 up here, the program acted like it haddn't happened. Why can I set other variabels values up here? Maybe I can't, since I have reopened this those lines seem to have stopped working as experianced before.
	public bool order_read_for_delivery, order_ready_to_produce;
	public List<string> FIFO_queue_of_orders;
	public string current_order;
	public string target_directory;
	public string current_directory;
	public string curent_target_file;
	public List<string> elements_from_order_file;

	public void search_for_new_order()//Check every frame?
	{

	}

	public void fulfill_order()//fires when an order is ready to produce.
	{
		//fulfill the order
		order_up_to_x_fulfilled++;//incriment the order number to be fulfilled.
	}

	public void act()
	{
		Debug.Log (current_directory);
		/*
		current_target_file = target_directory + @"\" + order_up_to_x_fulfilled.ToString() + ".csv";
		Debug.Log (current_target_file);
		if (File.Exists(current_target_file))
		{

			Debug.Log ("Target file:" + current_target_file + " found.");

			using (var reader = new StreamReader (current_target_file))//https://stackoverflow.com/questions/5282999/reading-csv-file-and-storing-values-into-an-array
			{

				while (!reader.EndOfStream) 
				{
				
					var line = reader.ReadLine ();
					var values = line.Split (',');
					elements_from_order_file.Add (values [0]);//table_number
					elements_from_order_file.Add (values [1]);//unfulfilled_items
					elements_from_order_file.Add (values [2]);//fulfilled_items

				}
					
			}
		
		}
	*/
	}

	// Use this for initialization
	void Start () 
	{
		//Directory.SetCurrentDirectory(target_directory);//This being here causes unity to close for some reason.
		order_up_to_x_fulfilled = 1;
		target_directory = Directory.GetCurrentDirectory() + @"\Assets\scripts";
		current_directory = Directory.GetCurrentDirectory();


	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKey(KeyCode.A))//move on "world" x axis
		{

			act ();

		}

	}
}
