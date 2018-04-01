using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    public BoardManager boardManager;
    public ButtonManager buttonManager;
    //public Dictionary<Item, int> items;
    public Dictionary<string, Dictionary<Item, int>> inventory;

    public GameObject itemPrefab;
    // Use this for initialization
    void Start () {
        //boardManager = GameObject.Find("BoardManagerHolder").GetComponent<BoardManager>();
        //items = new Dictionary<Item, int>();
        //CreateItem("General", "Fire Seeds", 132);
        inventory = new Dictionary<string, Dictionary<Item, int>>();
        inventory.Add("Fruits", new Dictionary<Item, int>());
        inventory.Add("Essences", new Dictionary<Item, int>());
        inventory.Add("Seeds", new Dictionary<Item, int>());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void CreateItem(string category, string name, int amount)
    //{
    //    GameObject item = (GameObject) Instantiate(itemPrefab);
    //    SetItemInfo(category, item, name, amount);
    //}

    //public void SetItemInfo(string category, GameObject item, string name, int amount)
    //{
    //    item.transform.SetParent(GameObject.Find(category).transform);
    //    item.transform.localScale = new Vector3(1, 1, 1);
    //    //item.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = itemType.spriteList[0];
    //    item.transform.GetChild(1).GetComponent<Text>().text = name;
    //    item.transform.GetChild(2).GetComponent<Text>().text = "x " + amount;
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
                return;
            }
        }
        inventory[inventoryKey].Add(itemToAdd, amount);
        CreateItem(inventoryKey, itemToAdd, amount);
        print("Added " + itemToAdd.itemName + " x" + amount + " to inventory[" + inventoryKey + "]!");
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
}
