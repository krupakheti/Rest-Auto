using UnityEngine;
using UnityEngine.UI;

public class TakeOrders : MonoBehaviour {
    public Button foodOne_button, foodTwo_button, foodThree_button, foodFour_button, finished_button;
    //public int table_number;
    //public List<string> orders;

	// Use this for initialization
	void Start () {
        foodOne_button.onClick.AddListener(writeFoodToFile);
        foodTwo_button.onClick.AddListener(writeFoodToFile);
        foodThree_button.onClick.AddListener(writeFoodToFile);
        foodFour_button.onClick.AddListener(writeFoodToFile);
        finished_button.onClick.AddListener(finishOrder);

	}

    public void writeFoodToFile()
    {
        //make order
        Debug.Log("Write order to file.");

    }
   

    void finishOrder()
    {
        //return to table screen
        Debug.Log("Send order to kitchen.");
    }

}
