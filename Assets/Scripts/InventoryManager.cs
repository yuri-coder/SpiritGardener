using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public BoardManager boardManager;
    public ButtonManager buttonManager;
    //public Dictionary<Item, int> items;
    public Dictionary<string, Dictionary<Item, int>> inventory;
    // Use this for initialization
    void Start () {
        //boardManager = GameObject.Find("BoardManagerHolder").GetComponent<BoardManager>();
        //items = new Dictionary<Item, int>();
        inventory = new Dictionary<string, Dictionary<Item, int>>();
        inventory.Add("fruits", new Dictionary<Item, int>());
        inventory.Add("essences", new Dictionary<Item, int>());
        inventory.Add("seeds", new Dictionary<Item, int>());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(Item itemToAdd, int amount, string inventoryKey)
    {
        print("Entered AddItem");
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
        print("Added " + itemToAdd.itemName + " x" + amount + " to inventory[" + inventoryKey + "]!");
    }

    public void AddMultipleItems(Dictionary<Item, int> items)
    {
        print("Entered AddMultipleItems");
        foreach(KeyValuePair<Item, int> item in items)
        {
            string inventoryKey = "false";
            if(item.Key is Fruit)
            {
                inventoryKey = "fruits";
            }
            else if(item.Key is Essence)
            {
                inventoryKey = "essences";
            }
            else if(item.Key is Seed)
            {
                inventoryKey = "seeds";
            }
            AddItem(item.Key, item.Value, inventoryKey);
        }
    }
}
