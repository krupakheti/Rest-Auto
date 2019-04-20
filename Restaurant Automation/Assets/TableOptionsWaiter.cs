using UnityEngine;
using UnityEngine.UI;

public class TableOptionsWaiter : MonoBehaviour {

    public Button m_AddFoodButton, m_ReadytoCleanButton;

	// Use this for initialization
	void Start () {

        m_AddFoodButton.onClick.AddListener(GoToMenu);
        m_ReadytoCleanButton.onClick.AddListener(AlertBusser);
		
	}
	
    void GoToMenu()
    {
        //Go to menu canvas, unsure of how to do
        Debug.Log("Go to menu canvas, under take orders?");
    }

    void AlertBusser()
    {
        //Go to busser canvas
        Debug.Log("Go to busser canvas");
    }
	// Update is called once per frame
	void Update () {
		
	}

}
