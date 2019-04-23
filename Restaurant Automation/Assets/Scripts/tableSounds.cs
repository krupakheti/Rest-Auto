using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tableSounds : MonoBehaviour {
    private keypadSounds player;
    private GameObject[] tables;


	// Use this for initialization
	void Start () {
		player = (GameObject.FindGameObjectWithTag("Player").GetComponent<keypadSounds>());
        tables = GameObject.FindGameObjectsWithTag("button");
        foreach(GameObject currentTable in tables) addOnClick(currentTable);
	}

    private void addOnClick(GameObject currentTable)
    {
        Button tableButton = currentTable.GetComponent<Button>();
        tableButton.onClick.AddListener(onClick);

    }

    private void onClick()
    {
        player.playSound(3);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
