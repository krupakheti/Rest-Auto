using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tableHighlight : MonoBehaviour {

	public GameObject mainCanvas;
	public List<Button> tableButtons;
    public int loginNumber;
    public List<Button> tablesToHighlight;
    public Button callingTable;
    public GameObject popupPrefab;

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



		//determine tables that need attending		
        determineProblemTables();
        //highlight tables that need attending		
        foreach(Button currentButton in tablesToHighlight) { 
                //Debug.Log("foreach button");
                                                        //highlightSpecificButton(currentButton, Color.red);        
            }        
    }//end of Start()

    //Determine which tables will be highlighted as "need to be attended" by current employee
    private void determineProblemTables()
    {
        int firstDigit = loginNumber;        
        if (firstDigit == 1)
        {
            //Debug.Log("Go to host interface");
            foreach(Button currentTable in tableButtons) { 
                if(checkCondition(1, currentTable)) { 
                    tablesToHighlight.Add(currentTable);    
                }    
            }
        }
        if (firstDigit == 2)
        {
            //Debug.Log("Go to waiter interface");
            foreach(Button currentTable in tableButtons) { 
                if(checkCondition(2, currentTable)) { 
                    tablesToHighlight.Add(currentTable);    
                }    
            }
        }
        if (firstDigit == 3)
        {
            //Debug.Log("Go to kitchen interface");
            foreach(Button currentTable in tableButtons) { 
                if(checkCondition(3, currentTable)) { 
                    tablesToHighlight.Add(currentTable);    
                }    
            }
        }
        if (firstDigit == 4)
        {
            //Debug.Log("Go to busser interface");
            foreach(Button currentTable in tableButtons) { 
                if(checkCondition(4, currentTable)) { 
                    tablesToHighlight.Add(currentTable);    
                }    
            }
        }
    }

    //Determines whether a table requires the attention of the current employee
    public bool checkCondition(int employeeType, Button currentTable)
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


