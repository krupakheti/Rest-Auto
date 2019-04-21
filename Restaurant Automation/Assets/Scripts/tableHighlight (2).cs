using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tableHighlight : MonoBehaviour {

	public GameObject mainCanvas;
	public List<Button> tableButtons;
    public int loginNumber;
<<<<<<< HEAD
    public List<Button> tablesToHighlight;
    public Button callingTable;
    public GameObject popupPrefab;
=======
    public Button tablesToHighlight;
>>>>>>> parent of ba652f0... Table highlighting works for every employee type

	// When the scene starts, this will run ONCE
	void Start () {
		// Make an array of all the buttons with the tag 'button'
		GameObject[] btn = GameObject.FindGameObjectsWithTag("button");
		// Iterate through the array of 'btn' and add them to the 'buttons' list
		for (int i = 0; i < btn.Length; i++)
		{
			// Adding the current 'btn' to the 'buttons' list
			//tableButtons.Add(btn[i].GetComponent<Button>());
		}

<<<<<<< HEAD


		//determine tables that need attending		
        determineProblemTables();
        //highlight tables that need attending		
        foreach(Button currentButton in tablesToHighlight) { 
                //Debug.Log("foreach button");
                highlightSpecificButton(currentButton, Color.red);        
            }        
=======
		//run the function called "HighlightButtons"
		HighlightButtons();
        highlightSpecificButton(tablesToHighlight, Color.red);


>>>>>>> parent of ba652f0... Table highlighting works for every employee type
    }//end of Start()
	
	// Update is called once per frame
	void Update () {

        //highlightSpecificButton(this.gameObject.GetComponent<Button>(), Color.red);
		
	}

	// Example function making all of the buttons, non-interactable
	private void HighlightButtons()
	{
		// Iterate through each button in the 'buttons' list & set interactable to false
		for (int i = 0; i < tableButtons.Count; i++)
		{
			//tableButtons[i].interactable = false;
			// And do what ever else you want with the buttons

<<<<<<< HEAD
    //Determines whether a table requires the attention of the current employee
    private bool checkCondition(int employeeType, Button currentTable)
    {
        tableInfo currentTableInfo = currentTable.gameObject.GetComponent<tableInfo>();
        printInfo(currentTableInfo);


        //Debug.Log(currentTableInfo.occupied + " " + currentTableInfo.waitingToOrder);
        if(employeeType == 1) {if(currentTableInfo.occupied == false) return true;}
        if(employeeType == 2) {if(currentTableInfo.waitingToOrder == true) return true;}
        if(employeeType == 3) {if(currentTableInfo.order.Count > 1) return true;}
        if(employeeType == 4) {if(currentTableInfo.clean == false) return true;}
        
        /*
        switch (employeeType) { 
            //Host
            case 1: if(currentTableInfo.occupied == false) return true;
            break;
            //Waiter
            case 2: if(currentTableInfo.waitingToOrder == true) return true;
            break;
            //Kitchen
            case 3: if(currentTableInfo.order.Count != 0) return true;
            break;
            //Busser
            case 4: if(currentTableInfo.clean == false && currentTableInfo.occupied == false) return true;
            break;
            default: Debug.Log("Default checkCondition: " + currentTableInfo.tableNumber); 
            break;
        }
        Debug.Log("Outside switch, returning False");
        */
        //Debug.Log("Employee type: " + employeeType);
        return false;
    }

    private void printInfo(tableInfo currentTableInfo)
    {
       currentTableInfo.toString();
    }
=======
			//Change each button's color to yellow
            Debug.Log(tableButtons[i].ToString());
			ColorBlock cb = tableButtons[i].colors;
			cb.normalColor = Color.yellow;
			tableButtons[i].colors = cb;

			//Print the button's name to the console
			//Debug.Log(tableButtons[i].gameObject.name);
		}
	}//end of HighlightButtons()
>>>>>>> parent of ba652f0... Table highlighting works for every employee type

    public void highlightSpecificButton(Button thisButton, Color thisColor) {

        //Change the button's color to the passed in color
        ColorBlock cb = thisButton.colors;
        cb.normalColor = thisColor;
        thisButton.colors = cb;
         
    }//end of color specific button

    public int getLoginNumber() {return loginNumber;}

    public void setCallingTable(Button thisButton) { 
        Debug.Log("Calling table = " + thisButton.GetComponent<tableInfo>().tableNumber);
        callingTable = thisButton;    
    }
    public Button getCallingTable() { 
        return callingTable;    
    }

    public void createPopup() {     
        Instantiate(popupPrefab, transform.position, Quaternion.identity);        
    }


}//end of class


