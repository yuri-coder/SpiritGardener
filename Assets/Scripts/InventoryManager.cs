using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    /*****************
     Static InventoryManager Instance 
     ****************/
    public static InventoryManager Instance;

    /*****************
     Game Managers
     ****************/
    public BoardManager boardManager;
    public ButtonManager buttonManager;

    /*****************
     Virtual Player Inventory
     ****************/
    public Dictionary<string, Dictionary<Item, int>> inventory;

    /*****************
     Navigation/History Related Variables
     ****************/
    public string currentMenu;
    public string lastClickedItem;

    /*****************
     Generic GameObject Prototypes and GameObject References
     ****************/
    public GameObject inventoryObject; //The entire Inventory GameObject (with General, etc.)
    public GameObject itemPrefab;


    // Use this for initialization
    void Awake()
    {
        Instance = this;    
    }

    void Start () {
        inventory = new Dictionary<string, Dictionary<Item, int>>();
        inventory.Add("Fruits", new Dictionary<Item, int>());
        inventory.Add("Essences", new Dictionary<Item, int>());
        inventory.Add("Seeds", new Dictionary<Item, int>());
        currentMenu = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    //When clicking on an item in the inventory, perform different actions based on the current menu
    public void ItemClick(GameObject clickedItem)
    {
        print(System.Environment.StackTrace);
        if (!clickedItem)
        {
            return;
        }

        print("Current Menu: " + currentMenu);
        InventoryItem inventoryItem = clickedItem.GetComponent<InventoryItem>();
        lastClickedItem = clickedItem.transform.GetChild(1).GetComponent<Text>().text;
        switch (currentMenu)
        {
            case "PlantSeed":
                print(inventoryItem.plantType);
                boardManager.activeSeed = inventoryItem.plantType;
                break;

            default:
                print(inventoryItem.description);
                break;
        }
    }

    //Instantiate a GameObject from a generic itemPrefab, then call SetItemInfo
    public void CreateItem(string category, Item itemType, int amount)
    {
        GameObject item = (GameObject)Instantiate(itemPrefab);
        SetItemInfo(category, item, itemType, amount);
    }

    //Set information about the item in the inventory slot GameObject
    public void SetItemInfo(string category, GameObject item, Item itemType, int amount)
    {
        //item.transform.SetParent(GameObject.Find(category).transform);
        item.transform.SetParent(inventoryObject.transform.Find("General").transform);
        item.transform.localScale = new Vector3(1, 1, 1);
        item.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = itemType.spriteList[0];
        item.transform.GetChild(1).GetComponent<Text>().text = itemType.itemName;
        item.transform.GetChild(2).GetComponent<Text>().text = "x " + amount;
        item.tag = category;

        InventoryItem inventoryItem = item.GetComponent<InventoryItem>();
        inventoryItem.description = itemType.description;
        
        switch (category)
        {
            case "Seeds":
                Seed seedType = (Seed)itemType;
                inventoryItem.plantType = seedType.plantType;
                break;
            default:
                break;
        }
    }

    //Add x amount of an item to the inventory in the appropriate inventoryKey slot
    public void AddItem(Item itemToAdd, int amount, string inventoryKey)
    {
        if (inventoryKey.Equals("false"))
        {
            print("Only fruits, essences, and seeds can be stored in the inventory!");
            return;
        }

        foreach (KeyValuePair<Item, int> entry in inventory[inventoryKey])
        {
            if (entry.Key.GetType() == itemToAdd.GetType())
            {
                inventory[inventoryKey][entry.Key] += amount;
                print("Added " + itemToAdd.itemName + " x" + amount + " to inventory[" + inventoryKey + "]!");
                SetItemAmount(itemToAdd, inventory[inventoryKey][entry.Key]);
                return;
            }
        }
        inventory[inventoryKey].Add(itemToAdd, amount);
        CreateItem(inventoryKey, itemToAdd, amount);
        print("Added " + itemToAdd.itemName + " x" + amount + " to inventory[" + inventoryKey + "]!");
    }

    //Subtract x amount of an item from the inventory based on a string of the name and a string of the appropriate inventory location
    public void SubtractItem(string itemToSubtract, int amount, string inventoryKey)
    {
        print("Entered Subtract Item: item to subtract is " + itemToSubtract);
        foreach (KeyValuePair<Item, int> entry in inventory[inventoryKey])
        {
            if (entry.Key.itemName.Equals(itemToSubtract))
            {
                if(entry.Value <= 0)
                {
                    print("0 " + entry.Key.itemName + " remaining!");
                    return;
                }
                inventory[inventoryKey][entry.Key] -= amount;
                print("Subtracted " + itemToSubtract + " x" + amount + " from inventory[" + inventoryKey + "]!");
                SetItemAmount(itemToSubtract, inventory[inventoryKey][entry.Key]);
                return;
            }
        }
    }

    //Set the amount of an item based on an Item object and amount
    private void SetItemAmount(Item item, int amount)
    {
        foreach (Transform itemContainer in inventoryObject.transform.Find("General").transform)
        {
            if (itemContainer.GetChild(1).GetComponent<Text>().text.Equals(item.itemName))
            {
                itemContainer.GetChild(2).GetComponent<Text>().text = "x " + amount;
                break;
            }
        }
    }

    //Set the amount of an item based on a string of the object's name and amount
    private void SetItemAmount(string item, int amount)
    {
        foreach (Transform itemContainer in inventoryObject.transform.Find("General").transform)
        {
            if (itemContainer.GetChild(1).GetComponent<Text>().text.Equals(item))
            {
                itemContainer.GetChild(2).GetComponent<Text>().text = "x " + amount;
                break;
            }
        }
    }

    //Determine what type of item is being added and call AddItem with that item's type as the inventoryKey*
    public void AddMultipleItems(Dictionary<Item, int> items)
    {
        foreach(KeyValuePair<Item, int> item in items)
        {
            string inventoryKey = "false";
            if(item.Key is Fruit)
            {
                inventoryKey = "Fruits";
            }
            else if(item.Key is Essence)
            {
                inventoryKey = "Essences";
            }
            else if(item.Key is Seed)
            {
                inventoryKey = "Seeds";
            }
            AddItem(item.Key, item.Value, inventoryKey);
        }
    }

    //Display all items in the inventory that match a certain tag
    public void DisplayByTag(string tag)
    {
        foreach (Transform itemContainer in inventoryObject.transform.Find("General").transform)
        {
            itemContainer.gameObject.SetActive(itemContainer.gameObject.CompareTag(tag));
        }
    }

    //Display all items in the inventory 
    public void DisplayAllItems()
    {

        foreach (Transform itemContainer in inventoryObject.transform.Find("General").transform)
        {
            itemContainer.gameObject.SetActive(true);
        }
    }
}
