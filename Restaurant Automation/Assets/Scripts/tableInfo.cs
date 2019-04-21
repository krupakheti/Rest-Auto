using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class tableInfo : MonoBehaviour {

    public int tableNumber;
    public bool occupied;
    public bool clean;
    public bool waitingToOrder;
    public List<string> order;
    public double bill = 0;
    public FileStream fileStream;
    //public GameObject sceneScriptsPrefab;
  
    public void markOccupied() {
        occupied = true;
        waitingToOrder = true;        
    }

    public void markClean() {        
        clean = true;        
    }

    public void markGuestsLeft() { 
        occupied = false;
        if(order.Count > 0) waitingToOrder = false;
        clean = false;
    }

    public void markOrderFilled() { 
        order.Clear();        
    }

    //called when the waitor adds an item to the order
    public void addItemToOrder(string item) {
        order.Add(item);
    }

    //called when the waitor is done modifying the order
    public void placeOrder() {
        writeToFile();
    }

	// Use this for initialization
	void Start () {
        string[] tableInformation = readInStrings();
        populateTables(tableInformation);

        //sceneScriptsPrefab.SetActive(true);
    }

    private void populateTables(string[] tableInformation)
    {
        for (int i = 0; i < 6; i++) {
            if(i+1==tableNumber) parseTableInfo(tableInformation[i], i+1);
        }
    }

    private void parseTableInfo(string thisTableInfo, int currentTable)
    {   
        Debug.Log("thisTableInfo: " + thisTableInfo);
        string[] words = thisTableInfo.Split(',');
        //Debug.Log("Words: " + words[2]);        
        if(int.Parse(words[0]) == tableNumber) { 
            //Debug.Log("Entered Setters");
            setOccupied(bool.Parse(words[1]));
            setClean(bool.Parse(words[2]));
            setW2O(bool.Parse(words[3]));
            setOrder(new List<string>(words[4].Split(' ')));
            setBill(double.Parse(words[5]));
        }

        /*
        //if(int.Parse(words[0]) == tableNumber) { 
            //tableNumber = int.Parse(words[0]);
            occupied = bool.Parse(words[1]);
            clean = bool.Parse(words[2]);
            waitingToOrder = bool.Parse(words[3]);
            order = new List<string>(words[4].Split(' '));
            //order.RemoveAt(order.Count - 1);
            bill = double.Parse(words[5]);
            */        
        //}
    }


    public void readFromFile() {
        string path = Application.persistentDataPath + "/tableInfo.csv";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }        
    

    public void writeToFile() {
        //string path = "Assets/Resources/tableInfo.csv";        
        string path = Application.persistentDataPath + "/newTableInfo.csv";        
        try
        {
            File.Delete(path);
        }
        catch {
            Debug.Log("Failed to delete file. Proceding.");
        }
        StreamWriter writer = new StreamWriter(path, true);
        //StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/newTableInfo.csv", true);

        string[] fileLines = readInStrings(); 

        //for each table
        for (int i = 0; i < 6; i++) {
            //check if current table is == current line of file (i)
            if (i == tableNumber-1)
            {
                //if it is, write current string to file   
                string thisTablesInfo = tableNumber + ","
                    + occupied.ToString() + ","
                    + clean.ToString() + ","
                    + waitingToOrder.ToString() + ","
                    + writeOrderToString(order) + ","
                    + bill.ToString();
                writer.WriteLine(thisTablesInfo);
            }
            //else, write existing string to file
            else {
                writer.WriteLine(fileLines[i]);
            }
        }
        writer.Dispose();
        writer.Close();

        File.Delete(Application.persistentDataPath + "/tableInfo.csv");
        File.Move(Application.persistentDataPath + "/newTableInfo.csv", Application.persistentDataPath + "/tableInfo.csv");
    }

    private string writeOrderToString(List<string> order) {
        string orderString = "";
        foreach (string thisItem in order) {
            orderString += thisItem + " ";
       }
        return orderString;
    }

    public string[] readInStrings() {
        string[] theseStrings = new string[6];
        //string path = "Assets/Resources/tableInfo.csv";
        //Debug.Log(Application.persistentDataPath.ToString());
        string path = Application.persistentDataPath + "/tableInfo.csv";
        StreamReader reader = new StreamReader(path);

        //Read the text from directly from the test.txt file
        for (int i = 0; i < 6; i++)
        {
            theseStrings[i] = reader.ReadLine();
            //Debug.Log(theseStrings[i]);
        }
        reader.Close();
        return theseStrings;
    }

    public void problemAddressed() { 
        Button thisButton = this.gameObject.GetComponent<Button>();
        ColorBlock cb = thisButton.colors;
        if(cb.normalColor == Color.red) {                 
             cb.normalColor = Color.green;
             thisButton.colors = cb;
        }     
    }
    
    public void toString() {         
        Debug.Log("Table Number: " + tableNumber + "\n");
        Debug.Log("Occupied: " + occupied + "\n");
        Debug.Log("Clean: " + clean + "\n");
        Debug.Log("W2O: " + waitingToOrder + "\n");
        Debug.Log("Order: " + order + "\n");
        Debug.Log("Bill: " + bill + "\n");        
    }

    public void setOccupied(bool occ) {
        occupied = occ;    
    }
    public void setClean(bool occ) {
        clean = occ;    
    }
    public void setW2O(bool occ) {
        waitingToOrder = occ;    
    }
    public void setOrder(List<string> occ) {
        order = occ;    
    }
    public void setBill(double occ) {
        bill = occ;    
    }
}

