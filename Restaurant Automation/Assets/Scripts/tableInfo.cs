using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class tableInfo : MonoBehaviour {

    public int tableNumber;
    public bool occupied, clean, waitingToOrder;
    public List<string> order;
    public double bill;
    public FileStream fileStream;

    public void markOccupied() {
        occupied = true;
        waitingToOrder = true;
        writeToFile();
    }

    public void markClean() {
        occupied = false;
        clean = true;
        writeToFile();
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
        //open the file, and create defautl table entries if needed
        //readFromFile();
        string[] tableInformation = readInStrings();
        populateTables(tableInformation);
    }

    private void populateTables(string[] tableInformation)
    {
        for (int i = 1; i < tableInformation.Length; i++) {
            parseTableInfo(tableInformation[i], i);
        }
    }

    private void parseTableInfo(string v, int i)
    {

        /****************************************************THIS IS WHERE YOU WERE WORKING***************************************************/
        //TODO:
    }

    public void readFromFile() {
        //look for file with name
        //if file does't exist: create a file with that name, then open it 
        //Create new file and open it for read and write, if the file exists throw exception

        //string path = "Assets/Resources/tableInfo.csv";
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
        for (int i = 0; i < 10; i++) {
            //check if current table is == current line of file (i)
            if (i == tableNumber)
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
        string[] theseStrings = new string[10];
        //string path = "Assets/Resources/tableInfo.csv";
        string path = Application.persistentDataPath + "/tableInfo.csv";
        StreamReader reader = new StreamReader(path);

        //Read the text from directly from the test.txt file
        for (int i = 0; i < 10; i++)
        {
            theseStrings[i] = reader.ReadLine();
            Debug.Log(theseStrings[i]);
        }
        reader.Close();
        return theseStrings;
    }

    

}

