using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup : MonoBehaviour {
    private Button actionButton;
    private Button cancelButton;
    private Button inputOrder, tableStatus, orderList;
    private int login;
    public List<Button> otherButtons;
    public Button callingButton;
    private tableHighlight colorMe;
    private tableInfo writeMe;
    private tableInfo updateTableData;
    public GameObject orderPopupPrefab;
    private keypadSounds player;

	// Use this for initialization
	void Start () {        
        colorMe = GameObject.FindObjectOfType<tableHighlight>();        
        callingButton = colorMe.getCallingTable();
        writeMe = callingButton.GetComponent<tableInfo>();
        login = colorMe.getLoginNumber();
        otherButtons.Clear();
        player = (GameObject.FindGameObjectWithTag("Player").GetComponent<keypadSounds>());       

        if(this.gameObject.name != "Order Popup(Clone)")
        {
            actionButton = GameObject.FindGameObjectWithTag("action").GetComponent<Button>();
            cancelButton = GameObject.FindGameObjectWithTag("cancel").GetComponent<Button>();
            inputOrder = GameObject.FindGameObjectWithTag("placeOrder").GetComponent<Button>();
            tableStatus = GameObject.FindGameObjectWithTag("other").GetComponent<Button>();
            orderList = GameObject.FindGameObjectWithTag("orderList").GetComponent<Button>();
            addActionClickMethod();
            cancelButton.onClick.AddListener(cancelClick);
            Text abText = actionButton.GetComponentInChildren<Text>();
            //Debug.Log(abText.text);
            renameActionButton(login, abText);
            Text tblStatus = tableStatus.GetComponentInChildren<Text>();
            setTableStatus(tblStatus, writeMe, login);
            populateOrderList();
        }
        else { 
            GameObject[] otherButtonsGO = GameObject.FindGameObjectsWithTag("other");        
            foreach(GameObject currentOtherButton in otherButtonsGO) {
                //Debug.Log(otherButtons.ToString());
                otherButtons.Add(currentOtherButton.GetComponent<Button>());
                clickHandler(currentOtherButton.GetComponent<Button>());
            }
            cancelButton = GameObject.FindGameObjectWithTag("orderCancel").GetComponent<Button>();
            cancelButton.onClick.AddListener(orderCancelClick);
        }                		
	}

    private void populateOrderList()
    {
        Text orderListText = orderList.GetComponentInChildren<Text>();
        foreach(string item in writeMe.order) { 
            orderListText.text += item + "\n"; 
        }

    }

    private void setTableStatus(Text tblStatus, tableInfo writeMe, int login)
    {               
            if(writeMe.waitingToOrder == true) tblStatus.text = "Waiting to Order.";
            else if(writeMe.bill > 0 && writeMe.order.Count >1) tblStatus.text = "Waiting for food.";
            else if(writeMe.bill > 0 && writeMe.order.Count <=1) tblStatus.text = "Waiting to pay.";
            else tblStatus.text = "Does not need attention.";         
    }

    private void renameActionButton(int login, Text buttonText)
    {
        if(login==1) buttonText.text = "Seat Guests";
        if(login==2) buttonText.text = "Guests Have Left";
        if(login==3) buttonText.text = "Order Completed";
        if(login==4) buttonText.text = "Table is Clean";
    }

    private void orderCancelClick()
    {
        //Debug.Log("OrderCancel button.");        
        Destroy(GameObject.FindGameObjectWithTag("orderPopup"));
        updateTableData = callingButton.GetComponent<tableInfo>();
        updateTableData.waitingToOrder = false;
        colorMe.highlightSpecificButton(callingButton, Color.green);
        writeMe.writeToFile();
        player.playSound(2);
    }

    private void clickHandler(Button thisButton)
    {                
        switch (thisButton.name) { 
            case "Burger": thisButton.onClick.AddListener(burgerButton);
            break;
            case "Chicken": thisButton.onClick.AddListener(chickenButton);
            break;
            case "Coffee": thisButton.onClick.AddListener(coffeeButton);
            break;
            case "Soda": thisButton.onClick.AddListener(sodaButton);
            break;
            default: Debug.Log("Incorrect Button Name");
            break;
        }
    }

    private void sodaButton()
    {
        //Debug.Log("SodaButton");
        writeMe.order.Add("Soda");
        writeMe.bill += 1.99; 
        player.playSound(1);
    }

    private void coffeeButton()
    {
        //Debug.Log("CoffeeButton");
        writeMe.order.Add("Coffee");
        writeMe.bill += 1.99; 
        player.playSound(1);
    }

    private void chickenButton()
    {
        //Debug.Log("Chicken Button");
        writeMe.order.Add("Chicken");
        writeMe.bill += 3.99;
        player.playSound(1);
    }

    private void burgerButton()
    {
        //Debug.Log("BurgerButton");
        writeMe.order.Add("Burger");
        writeMe.bill += 4.99;
        player.playSound(1);
    }

    private void addActionClickMethod()
    {
        switch (login) { 
            //Host
            case 1: actionButton.onClick.AddListener(hostOnClick);
                    inputOrder.gameObject.SetActive(false);
                    tableStatus.gameObject.SetActive(false);
                    orderList.gameObject.SetActive(false);
                    
            break;
            //Waiter
            case 2: actionButton.onClick.AddListener(waiterOnClickGuestsLeft);                    
                    inputOrder.onClick.AddListener(waiterOnClickInputOrder);
                    orderList.gameObject.SetActive(false);
            break;
            //Kitchen
            case 3: actionButton.onClick.AddListener(kitchenOnClick);                    
                    inputOrder.gameObject.SetActive(false);                    
            break;
            //Busser
            case 4: actionButton.onClick.AddListener(busserOnClick);
                    inputOrder.gameObject.SetActive(false);
                    tableStatus.gameObject.SetActive(false);
                    orderList.gameObject.SetActive(false);
            break;
            default: Debug.Log("Invalid Login in Popup.cs"); //default case
            break;
        }        
    }

    void hostOnClick()
	{
		//Debug.Log("Host Button; Guests Leaving.");
        updateTableData = callingButton.GetComponent<tableInfo>();
        updateTableData.markOccupied();
        colorMe.highlightSpecificButton(callingButton, Color.green);
        writeMe.writeToFile();
        player.playSound(1);
	}
    void waiterOnClickInputOrder()
	{
		//Debug.Log("Waiter Button; Input Order.");
        //Spawn new popup
        Instantiate(orderPopupPrefab, transform.position, Quaternion.identity);
        player.playSound(3);
	}
    void waiterOnClickGuestsLeft()
	{
		//Debug.Log("Waiter Button.");
        updateTableData = callingButton.GetComponent<tableInfo>();
        updateTableData.markGuestsLeft();
        colorMe.highlightSpecificButton(callingButton, Color.green);
        writeMe.writeToFile();
        player.playSound(1);
	}
    void kitchenOnClick()
	{
		//Debug.Log("Kitchen Button.");
        updateTableData = callingButton.GetComponent<tableInfo>();        
        updateTableData.markOrderFilled();
        colorMe.highlightSpecificButton(callingButton, Color.green);
        writeMe.writeToFile();
        player.playSound(1);
	}
    void busserOnClick()
	{
		//Debug.Log("Busser Button.");
        updateTableData = callingButton.GetComponent<tableInfo>();        
        updateTableData.markClean();
        colorMe.highlightSpecificButton(callingButton, Color.green);
        writeMe.writeToFile();
        player.playSound(1);
	}

    void cancelClick()
	{	
		//Debug.Log("Cancel button.");
        Destroy(GameObject.FindGameObjectWithTag("popup"));
        player.playSound(2);
	}



}
