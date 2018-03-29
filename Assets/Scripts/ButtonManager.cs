using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public GameObject nextButton;
    public GameObject checkButton;
    public GameObject harvestButton;
    public GameObject plantButton;
    public GameObject removeButton;
    public GameObject siphonButton;

    public void EnableButton(GameObject button)
    {
        button.SetActive(true);
    }

    public void DisableButton(GameObject button)
    {
        button.SetActive(false);
    }

    public void ResetPlantButtons()
    {
        checkButton.SetActive(false);
        harvestButton.SetActive(false);
        plantButton.SetActive(false);
        removeButton.SetActive(false);
        siphonButton.SetActive(false);
    }

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        ResetPlantButtons();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
