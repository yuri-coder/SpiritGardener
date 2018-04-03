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
    public GameObject backButton;
    public GameObject confirmButton;
    
    public BoardManager boardManager;
    public InventoryManager inventoryManager;

    public GameObject inventoryButton;
    public GameObject inventoryMenu;
    public GameObject inventoryScrollbar;

    public GameObject exchangeButton;
    public GameObject exchangeMenu;
    public GameObject exchangeScrollbar;

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
        backButton.SetActive(false);
        confirmButton.SetActive(false);
    }

    public void ToggleInventory()
    {
        inventoryMenu.SetActive(!inventoryMenu.activeInHierarchy);
        inventoryScrollbar.SetActive(!inventoryScrollbar.activeInHierarchy);
        inventoryButton.SetActive(!inventoryButton.activeInHierarchy);
    }

    public void DisplayInventory()
    {
        inventoryMenu.SetActive(true);
        inventoryScrollbar.SetActive(true);
        inventoryButton.SetActive(true);
    }

    public void HideInventory()
    {
        inventoryMenu.SetActive(false);
        inventoryScrollbar.SetActive(false);
        inventoryButton.SetActive(false);
    }

    public void ToggleExchange()
    {
        exchangeMenu.SetActive(!exchangeMenu.activeInHierarchy);
        exchangeScrollbar.SetActive(!exchangeScrollbar.activeInHierarchy);
        exchangeButton.SetActive(!exchangeButton.activeInHierarchy);
    }

    public void ToggleInventoryExchange()
    {
        ToggleInventory();
        ToggleExchange();
    }

    public void DisplayExchange()
    {
        exchangeMenu.SetActive(true);
        exchangeScrollbar.SetActive(true);
        exchangeButton.SetActive(true);
    }

    public void HideExchange()
    {
        exchangeMenu.SetActive(false);
        exchangeScrollbar.SetActive(false);
        exchangeButton.SetActive(false);
    }

    public void StepUpdate()
    {
        foreach (KeyValuePair<Vector2, GameObject> tile in boardManager.gameBoard)
        {
            // do something with entry.Value or entry.Key
            //print("In BoardManager StepUpdate");
            tile.Value.SendMessage("StepUpdate");
        }
        Back();
    }

    public void CheckPlant()
    {
        print("Check plant!");
        print(boardManager.activeTile.CheckPlant());
        //print(boardManager.activeTile.gameObject.transform.position);
    }

    public void HarvestPlant()
    {
        print("Harvest plant!");
        inventoryManager.AddMultipleItems(boardManager.activeTile.HarvestPlant());
        Back();
    }

    public void SiphonPlant()
    {
        print("Siphon plant!");
        inventoryManager.AddMultipleItems(boardManager.activeTile.SiphonPlant());
        Back();
    }

    public void RemovePlant()
    {
        print("Remove plant!");
        boardManager.activeTile.RemovePlant();
        Back();
    }

    public void PlantSeed()
    {
        DisplayInventory();
        HideExchange();
        plantButton.SetActive(false);
        confirmButton.SetActive(true);
        backButton.SetActive(true);
        inventoryManager.DisplayByTag("Seeds");
        //print("Previous Menu: " + inventoryManager.currentMenu);
        inventoryManager.currentMenu = "PlantSeed";
        //print("Current Menu: " + inventoryManager.currentMenu);

        //boardManager.activeTile.TempPlant();
        //boardManager.activeTile = null;
        //ResetPlantButtons();
    }


    public void ConfirmSeed()
    {
        print("Menu: " + inventoryManager.currentMenu);
        if (boardManager.activeSeed == "")
        {
            Back();
        }
        else
        {
            print("Active seed is " + boardManager.activeSeed);
            inventoryManager.SubtractItem(inventoryManager.lastClickedItem, 1, "Seeds");
            boardManager.activeTile.PlantFromString(boardManager.activeSeed);
            Back();
        }
    }

    public void Back()
    {
        inventoryManager.DisplayAllItems();
        ResetPlantButtons();
        boardManager.activeTile = null;
        boardManager.activeSeed = "";
        inventoryManager.currentMenu = "";
        inventoryManager.lastClickedItem = "";
    }

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        ResetPlantButtons();
        HideExchange();
        DisplayInventory();
        //boardManager = GameObject.Find("BoardManagerHolder").GetComponent<BoardManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
