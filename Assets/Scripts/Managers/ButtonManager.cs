using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    /*****************
     Static ButtonManager Instance
     ****************/
    public static ButtonManager Instance;

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

    /*****************
     Private UI Related Variables
     ****************/
    private bool forceInventoryExchangeDisplay; //if True, user can't toggle between Inventory and Exchange menus

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        ResetPlantButtons();
        HideExchange();
        DisplayInventory();
        forceInventoryExchangeDisplay = false;
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
        TradeManager.Instance.HideAllTradeInfo();
    }
    public void HideExchange()
    {
        exchangeMenu.SetActive(false);
        exchangeScrollbar.SetActive(false);
        exchangeButton.SetActive(false);
        TradeManager.Instance.HideAllTradeInfo();
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
        TradeManager.Instance.HideAllTradeInfo();
    }
    //Only allow toggling between if not being forced to display Inventory/Exchange menu
    public void ToggleInventoryExchange()
    {
        if(!forceInventoryExchangeDisplay)
        {
            ToggleInventory();
            ToggleExchange();
        }
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
        InventoryManager.Instance.IncreaseTurn(1);
        PlayerManager.Instance.RechargeEnergy(5);
        Back();
    }

    public void CheckPlant()
    {
        print("Check plant!");
        print("Max Energy: " + PlayerManager.Instance.maxEnergy);
        print("Current Energy: " + PlayerManager.Instance.CurrentEnergy());
        print(boardManager.activeTile.CheckPlant());
    }

    public void HarvestPlant()
    {
        print("Harvest plant!");
        if (PlayerManager.Instance.ConsumeEnergy(1))
        {
            DisplayInventory();
            HideExchange();
            inventoryManager.AddMultipleItems(boardManager.activeTile.HarvestPlant());
        }
        Reset();
    }

    public void SiphonPlant()
    {
        print("Siphon plant!");
        if (PlayerManager.Instance.ConsumeEnergy(1))
        {
            DisplayInventory();
            HideExchange();
            inventoryManager.AddMultipleItems(boardManager.activeTile.SiphonPlant());
        }
        Reset();
    }

    public void RemovePlant()
    {
        print("Remove plant!");
        DialogueManager.Instance.DisplayMessage("Removed " + boardManager.activeTile.currentPlant.plantName + "!");
        boardManager.activeTile.RemovePlant();
        Reset();
    }

    //Ready the PlantSeed menu
    public void PlantSeed()
    {
        DisplayInventory();
        HideExchange();
        forceInventoryExchangeDisplay = true;
        plantButton.SetActive(false);
        confirmButton.SetActive(true);
        backButton.SetActive(true);
        inventoryManager.DisplayByTag("Seeds");
        inventoryManager.currentMenu = "PlantSeed";
        DialogueManager.Instance.DisplayMessage("Which seed would you like to plant?");
    }

    //Confirms the previously selected seed and plants it in the active tile, subtracting 1 from the user's inventory
    public void ConfirmSeed()
    {
        if (boardManager.activeSeed == "")
        {
            Back();
        }

        else if (!PlayerManager.Instance.ConsumeEnergy(2))
        {
            Reset();
        }

        else
        {
            bool canPlant = inventoryManager.SubtractItem(inventoryManager.lastClickedItem, 1, "Seeds");
            if (canPlant)
            {
                inventoryManager.dialogueMessage = "";
                boardManager.activeTile.PlantFromString(boardManager.activeSeed);
                DialogueManager.Instance.DisplayMessage(inventoryManager.dialogueMessage + "Planted " + inventoryManager.lastClickedItem + "!");
                Reset();
            }
            else
            {
                DialogueManager.Instance.DisplayMessage("Not enough " + inventoryManager.lastClickedItem + "s!");
                Reset();
            }
        }
    }

    //Resets to the base "game state" with activeSeed, tile, menu, etc. set to defaults
    public void Reset()
    {
        inventoryManager.DisplayAllItems();
        ResetPlantButtons();
        boardManager.activeTile = null;
        boardManager.activeSeed = "";
        inventoryManager.currentMenu = "";
        inventoryManager.lastClickedItem = "";
        forceInventoryExchangeDisplay = false;
        BoardManager.Instance.HideCursor();
    }

    //Resets dialogue display and then resets the rest
    public void Back()
    {
        DialogueManager.Instance.DisplayMessage("");
        Reset();
    }


}
