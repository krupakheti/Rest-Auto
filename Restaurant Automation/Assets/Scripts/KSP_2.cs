using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KSP_2 : MonoBehaviour {

	public int order_up_to_x_fulfilled;//Why couldn't I set the value to 1 up here, the program acted like it haddn't happened. Why can I set other variabels values up here? Maybe I can't, since I have reopened this those lines seem to have stopped working as experianced before.
	public bool order_ready_for_delivery, order_ready_to_produce;
	public List<string> FIFO_queue_of_orders;
	public string current_target_file;
	public List<string> elements_from_order_file;
	public Button button;
	public string path_to_order_up_file;
	public string order_line;

	public void search_for_new_order()//Check every frame?
	{
		current_target_file = "Assets/Resources/" + order_up_to_x_fulfilled.ToString() + ".csv";//form the currenttarget file
		Debug.Log("searching for: " + current_target_file);
		if (File.Exists (current_target_file))//if it exists
		{
			order_ready_for_delivery = false;
			get_order_info ();//get it's info.
			order_ready_to_produce = true;//set the order as ready to produce.

			foreach (string item in elements_from_order_file) 
			{
			
				Debug.Log(item);
			
			}

		} 
		else//if not
		{
			Debug.Log ("No newer order to fulfill.");//tell us
		}
	}

	public void fulfill_order()//fires when an order is ready to produce.
	{
		//fulfill the order

		order_ready_to_produce = false;
		order_ready_for_delivery = true;
		elements_from_order_file.Clear();//empty the vector of the now fulfilled order's data.



		//write to order_up_file--\/


		File.WriteAllText (path_to_order_up_file, String.Empty);//https://stackoverflow.com/questions/2695444/clearing-content-of-text-file-using-c-sharp
		StreamWriter writer = new StreamWriter (path_to_order_up_file, true);//https://support.unity3d.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
		writer.WriteLine (order_up_to_x_fulfilled.ToString ());
		Debug.Log ("Should have written " + order_up_to_x_fulfilled.ToString () + " out to " + path_to_order_up_file);
		writer.Close();


		//write to order_up_file--/\

		order_up_to_x_fulfilled++;//incriment the order number to be fulfilled.
		order_line = "";

	}

	public void get_order_info()
	{
		
		//read in the current target file's data--\/

		StreamReader reader = new StreamReader(current_target_file);//create "stream reader" from current file.
		string string_from_file = reader.ReadToEnd();//get the raw text of the file
		reader.Close();//close the "stream reader"


        
		//parse the raw text--\/

		string [] lines_from_file = string_from_file.Split (new[] { Environment.NewLine }, StringSplitOptions.None);//https://stackoverflow.com/questions/1547476/easiest-way-to-split-a-string-on-newlines-in-net
		string data_line = lines_from_file [1];
		string [] comma_split_data_line = data_line.Split (',');
		string table_number_of_current_order = comma_split_data_line [0];
		string un_parsed_order_items_of_current_order = comma_split_data_line [1];
		order_line = un_parsed_order_items_of_current_order;
		string[] seperate_current_order_items = un_parsed_order_items_of_current_order.Split (':');

		//parse the raw text--/\



		//store it to be used by other functions--\/

		elements_from_order_file.Add(table_number_of_current_order);
		foreach (string order_item in seperate_current_order_items) 
		{
		
			elements_from_order_file.Add(order_item);
		
		}

		//store it to be used by other functions--/\

		//read in the current target file's data--/\
	
	}

	public void act()
	{
		Debug.Log("act function called");
		search_for_new_order ();
	}




	// Use this for initialization
	void Start () 
	{

		order_up_to_x_fulfilled = 1;
		path_to_order_up_file = "Assets/Resources/order_up_file.txt";

	}

	public void buttonCLick_0()
	{
		if (!order_ready_to_produce) {
		
			search_for_new_order ();
		
		} else 
		{
		
			fulfill_order();
		
		}
		Debug.Log ("Button click recognized.");
	}



	//This displayes the current order, as an unparsed line of items, to the screen--\/
	void OnGUI ()
	{
		GUI.Label (new Rect (10, 10, 200, 90), "current order: " + order_line);//https://stackoverflow.com/questions/31007997/displaying-variables-using-gui-in-unity
	}

	//This displayes the current order, as an unparsed line of items, to the screen--/\




	// Update is called once per frame
	void Update () 
	{

		if (order_ready_to_produce) {


			//change color of button to indicate an order is ready to be fullfilled--\/
			//https://answers.unity.com/questions/1401626/how-to-change-button-color-highlited-color-etc.html

			ColorBlock colors = button.colors;
			colors.normalColor = Color.blue;
			colors.highlightedColor = new Color32 (100, 100, 255, 255);
			button.colors = colors;

			//change color of button to indicate an order is ready to be fullfilled--/\

		} else 
		{
		
			//change color of button to indicate an order needs to be searched for--\/

			ColorBlock colors = button.colors;
			colors.normalColor = Color.red;
			colors.highlightedColor = new Color32 (255, 100, 100, 255);
			button.colors = colors;

			////change color of button to indicate an order needs to be searched for--/\
		
		}

	}
}
