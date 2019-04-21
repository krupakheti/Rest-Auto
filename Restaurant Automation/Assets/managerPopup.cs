using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerPopup : MonoBehaviour {
    private GameObject[] buttons;
    public List<Button> otherButtons;
    private StaticClass muhStaticClass;
    private keypadSounds player;
    private Button cancelButton;

	// Use this for initialization
	void Start () {
        muhStaticClass = GameObject.FindObjectOfType<StaticClass>();
        otherButtons.Clear();
		buttons = GameObject.FindGameObjectsWithTag("other");
        foreach(GameObject currentOtherButton in buttons) {
                //Debug.Log(buttons.ToString());
                otherButtons.Add(currentOtherButton.GetComponent<Button>());
                clickHandler(currentOtherButton.GetComponent<Button>());
            }
        cancelButton = GameObject.FindGameObjectWithTag("orderCancel").GetComponent<Button>();
        cancelButton.onClick.AddListener(cancelButtonOnClick);
        player = GameObject.FindObjectOfType<keypadSounds>();
	}

    private void cancelButtonOnClick()
    {
        Destroy(GameObject.FindGameObjectWithTag("manager"));
        player.playSound(4);
    }

    private void clickHandler(Button thisButton)
    {                
        switch (thisButton.name) { 
            case "Host": thisButton.onClick.AddListener(hostButton);
            break;
            case "Waiter": thisButton.onClick.AddListener(waiterButton);
            break;
            case "Kitchen": thisButton.onClick.AddListener(kitchenButton);
            break;
            case "Busser": thisButton.onClick.AddListener(busserButton);
            break;
            default: Debug.Log("Incorrect Button Name");
            break;
        }
    }

    private void busserButton()
    {
        muhStaticClass.setLogin(4);
    }

    private void kitchenButton()
    {
        muhStaticClass.setLogin(3);
    }

    private void waiterButton()
    {
        muhStaticClass.setLogin(2);
    }

    private void hostButton()
    {
        muhStaticClass.setLogin(1);
    }



    // Update is called once per frame
    void Update () {
		
	}
}
