using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tableHighlight : MonoBehaviour {

	public GameObject mainCanvas;
	public List<Button> tableButtons;
    public int loginNumber;
    public int[] tablesToHighlight;

	// When the scene starts, this will run ONCE
	void Start () {
		// Make an array of all the buttons with the tag 'button'
		GameObject[] btn = GameObject.FindGameObjectsWithTag("button");
		// Iterate through the array of 'btn' and add them to the 'buttons' list
		for (int i = 0; i < btn.Length; i++)
		{
			// Adding the current 'btn' to the 'buttons' list
			tableButtons.Add(btn[i].GetComponent<Button>());
		}

		//run the function called "HighlightButtons"
		HighlightButtons();

	}//end of Start()
	
	// Update is called once per frame
	void Update () {
		
	}

	// Example function making all of the buttons, non-interactable
	private void HighlightButtons()
	{
		// Iterate through each button in the 'buttons' list & set interactable to false
		for (int i = 0; i < tableButtons.Count; i++)
		{
			//tableButtons[i].interactable = false;
			// And do what ever else you want with the buttons

			//Change each button's color to yellow
			ColorBlock cb = tableButtons[i].colors;
			cb.normalColor = Color.yellow;
			tableButtons[i].colors = cb;

			//Print the button's name to the console
			//Debug.Log(tableButtons[i].gameObject.name);
		}
	}//end of HighlightButtons()

    public void highlightSpecificButton(Button thisButton, ColorBlock thisColor) {

        //Change the button's color to the passed in color
       // thisButton.co
       /*
        ColorBlock cb = tableButtons[i].colors;
        cb.normalColor = Color.yellow;
        tableButtons[i].colors = cb;
        */
    }//end of color specific button

}//end of class


