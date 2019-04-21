using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorizor : MonoBehaviour {
    public List<Button> tables;
    private List<Button> tablesToHighlight;
    private Button thisButton, callingButton;
    private tableHighlight colorMe;
    private tableInfo writeMe;
    private int login;

	// Use this for initialization
	void Start () {
		thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(onClick);
        colorMe = GameObject.FindObjectOfType<tableHighlight>();        
        callingButton = colorMe.getCallingTable();
        writeMe = callingButton.GetComponent<tableInfo>();
        login = colorMe.getLoginNumber();
        tablesToHighlight = colorMe.tablesToHighlight;
        tablesToHighlight.Clear();

        onClick();
	}

    void onClick() { 
        //read file
        string[] fileContents = writeMe.readInStrings();
        //populate table values
        writeMe.populateAllTables(fileContents);
        //identify problems    
        determineProblemTables();
        //color em
        foreach(Button currentButton in tablesToHighlight) { 
                //Debug.Log("foreach button");
                colorMe.highlightSpecificButton(currentButton, Color.red);        
            }
    }

    private void determineProblemTables()
    {
        tablesToHighlight.Clear();
        int firstDigit = login;        
        if (firstDigit == 1)
        {
            //Debug.Log("Go to host interface");
            foreach(Button currentTable in tables) { 
                if(colorMe.checkCondition(1, currentTable)) { 
                    tablesToHighlight.Add(currentTable);    
                }    
            }
        }
        if (firstDigit == 2)
        {
            //Debug.Log("Go to waiter interface");
            foreach(Button currentTable in tables) { 
                if(colorMe.checkCondition(2, currentTable)) { 
                    tablesToHighlight.Add(currentTable);    
                }    
            }
        }
        if (firstDigit == 3)
        {
            //Debug.Log("Go to kitchen interface");
            foreach(Button currentTable in tables) { 
                if(colorMe.checkCondition(3, currentTable)) { 
                    tablesToHighlight.Add(currentTable);    
                }    
            }
        }
        if (firstDigit == 4)
        {
            //Debug.Log("Go to busser interface");
            foreach(Button currentTable in tables) { 
                if(colorMe.checkCondition(4, currentTable)) { 
                    tablesToHighlight.Add(currentTable);    
                }    
            }
        }
    }

}
