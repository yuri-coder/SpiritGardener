using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager Instance;
    public BoardManager boardManager;
    public ButtonManager buttonManager;
    //public Dictionary<Item, int> items;
    public Dictionary<string, Dictionary<Item, int>> inventory;
    public string currentMenu;
    public string lastClickedItem;

    public GameObject itemPrefab;
    // Use this for initialization

    void Awake()
    {
        Instance = this;    
    }

    void Start () {
        //boardManager = GameObject.Find("BoardManagerHolder").GetComponent<BoardManager>();
        //items = new Dictionary<Item, int>();
        //CreateItem("General", "Fire Seeds", 132);
        inventory = new Dictionary<string, Dictionary<Item, int>>();
        inventory.Add("Fruits", new Dictionary<Item, int>());
        inventory.Add("Essences", new Dictionary<Item, int>());
        inventory.Add("Seeds", new Dictionary<Item, int>());
        currentMenu = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}



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
                //print("In Plant Seed");
                print(inventoryItem.plantType);
                boardManager.activeSeed = inventoryItem.plantType;
                break;

            default:
                //print("Not in plant seed");
                print(inventoryItem.description);
                break;
        }
    }

    //private string checkCurrentMenu()
    //{
    //    return currentMenu;
    //}

    public void CreateItem(string category, Item itemType, int amount)
    {
        GameObject item = (GameObject)Instantiate(itemPrefab);
        SetItemInfo(category, item, itemType, amount);
    }

    public void SetItemInfo(string category, GameObject item, Item itemType, int amount)
    {
        //item.transform.SetParent(GameObject.Find(category).transform);
        item.transform.SetParent(GameObject.Find("General").transform);
        item.transform.localScale = new Vector3(1, 1, 1);
        item.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = itemType.spriteList[0];
        item.transform.GetChild(1).GetComponent<Text>().text = itemType.itemName;
        item.transform.GetChild(2).GetComponent<Text>().text = "x " + amount;
        item.tag = category;

        InventoryItem inventoryItem = item.GetComponent<InventoryItem>();
        inventoryItem.description = itemType.description;

        //item.AddComponent<InventoryItem>();
        
        switch (category)
        {
            case "Seeds":
                print("In seeds");
                Seed seedType = (Seed)itemType;
                print("Initial seed type: " + seedType.plantType);
                inventoryItem.plantType = seedType.plantType;
                print("Set seed type: " + inventoryItem.plantType);
                break;
            default:
                print("Not a seed!");
                break;
        }
    }

    public void AddItem(Item itemToAdd, int amount, string inventoryKey)
    {
        //print("Entered AddItem");
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

    public void SubtractItem(Item itemToSubtract, int amount, string inventoryKey)
    {

    }

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

    private void SetItemAmount(Item item, int amount)
    {
        foreach (Transform itemContainer in GameObject.Find("General").transform)
        {
            if (itemContainer.GetChild(1).GetComponent<Text>().text.Equals(item.itemName))
            {
                itemContainer.GetChild(2).GetComponent<Text>().text = "x " + amount;
                break;
            }
        }
    }

    private void SetItemAmount(string item, int amount)
    {
        foreach (Transform itemContainer in GameObject.Find("General").transform)
        {
            if (itemContainer.GetChild(1).GetComponent<Text>().text.Equals(item))
            {
                itemContainer.GetChild(2).GetComponent<Text>().text = "x " + amount;
                break;
            }
        }
    }

    public void AddMultipleItems(Dictionary<Item, int> items)
    {
        //print("Entered AddMultipleItems");
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

    public void DisplayByTag(string tag)
    {
        foreach (Transform itemContainer in GameObject.Find("General").transform)
        {
            itemContainer.gameObject.SetActive(itemContainer.gameObject.CompareTag(tag));
        }
    }

    public void DisplayAllItems()
    {

        foreach (Transform itemContainer in GameObject.Find("General").transform)
        {
            itemContainer.gameObject.SetActive(true);
        }
    }
}
