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
    public BoardManager boardManager;

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

    public void StepUpdate()
    {
        foreach (KeyValuePair<Vector2, GameObject> tile in boardManager.gameBoard)
        {
            // do something with entry.Value or entry.Key
            //print("In BoardManager StepUpdate");
            tile.Value.SendMessage("StepUpdate");
        }
        ResetPlantButtons();
        boardManager.activeTile = null;
    }

    public void CheckPlant()
    {
        print("Check plant!");
        print(boardManager.activeTile.CheckPlant());
        print(boardManager.activeTile.gameObject.transform.position);
    }

    public void HarvestPlant()
    {
        print("Harvest plant!");
        boardManager.activeTile = null;
        ResetPlantButtons();
    }

    public void SiphonPlant()
    {
        print("Siphon plant!");
        boardManager.activeTile = null;
        ResetPlantButtons();
    }

    public void RemovePlant()
    {
        print("Remove plant!");
        boardManager.activeTile.RemovePlant();
        boardManager.activeTile = null;
        ResetPlantButtons();
    }

    public void PlantSeed()
    {
        print("Temp plant seed!");
        boardManager.activeTile.TempPlant();
        boardManager.activeTile = null;
        ResetPlantButtons();
    }

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        ResetPlantButtons();
        boardManager = GameObject.Find("BoardManagerHolder").GetComponent<BoardManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
