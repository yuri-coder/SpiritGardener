using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    /*****************
     Game Managers
     ****************/
    public BoardManager boardManager;
    public InventoryManager inventoryManager;

    /*****************
     General Buttons
     ****************/
    public GameObject nextButton;

    /*****************
     Buttons for Plant Actions
     ****************/
    public GameObject checkButton;
    public GameObject harvestButton;
    public GameObject plantButton;
    public GameObject removeButton;
    public GameObject siphonButton;

    /*****************
     Sub Menu Buttons (inside Plant menu, etc.)
     ****************/
    public GameObject backButton;
    public GameObject confirmButton;

    /*****************
     Inventory Related UI 
     ****************/
    public GameObject inventoryButton;
    public GameObject inventoryMenu;
    public GameObject inventoryScrollbar;

    /*****************
     Exchange Related UI
     ****************/
    public GameObject exchangeButton;
    public GameObject exchangeMenu;
    public GameObject exchangeScrollbar;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        ResetPlantButtons();
        HideExchange();
        DisplayInventory();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableButton(GameObject button)
    {
        button.SetActive(true);
    }
    public void DisableButton(GameObject button)
    {
        button.SetActive(false);
    }
    
    //Resets all Plant Action and Sub Menu buttons
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

    /*****************
     Inventory/Exchange UI related toggles
     ****************/
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
    public void ToggleInventory()
    {
        inventoryMenu.SetActive(!inventoryMenu.activeInHierarchy);
        inventoryScrollbar.SetActive(!inventoryScrollbar.activeInHierarchy);
        inventoryButton.SetActive(!inventoryButton.activeInHierarchy);
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


    /*****************
     Plant Related Actions
     ****************/
    public void StepUpdate()
    {
        foreach (KeyValuePair<Vector2, GameObject> tile in boardManager.gameBoard)
        {
            tile.Value.SendMessage("StepUpdate");
        }
        Back();
    }

    public void CheckPlant()
    {
        print("Check plant!");
        print(boardManager.activeTile.CheckPlant());
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

    //Ready the PlantSeed menu
    public void PlantSeed()
    {
        DisplayInventory();
        HideExchange();
        plantButton.SetActive(false);
        confirmButton.SetActive(true);
        backButton.SetActive(true);
        inventoryManager.DisplayByTag("Seeds");
        inventoryManager.currentMenu = "PlantSeed";
    }

    //Confirms the previously selected seed and plants it in the active tile, subtracting 1 from the user's inventory
    public void ConfirmSeed()
    {
        if (boardManager.activeSeed == "")
        {
            Back();
        }
        else
        {
            inventoryManager.SubtractItem(inventoryManager.lastClickedItem, 1, "Seeds");
            boardManager.activeTile.PlantFromString(boardManager.activeSeed);
            Back();
        }
    }

    //Resets to the base "game state" with activeSeed, tile, menu, etc. set to defaults
    public void Back()
    {
        inventoryManager.DisplayAllItems();
        ResetPlantButtons();
        boardManager.activeTile = null;
        boardManager.activeSeed = "";
        inventoryManager.currentMenu = "";
        inventoryManager.lastClickedItem = "";
    }


}
