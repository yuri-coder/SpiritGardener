using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trade : MonoBehaviour {

    public Dictionary<string, int> itemsNeeded;
    public string itemReceived;
    public int amountReceived;
    public List<GameObject> requiredItems;
    public GameObject confirmButton;
    public GameObject requiredItemPrefab;
    public bool displayingInfo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializeTrade(Dictionary<string, int> needed, string receivedItem, int receivedAmount)
    {
        itemsNeeded = needed;
        itemReceived = receivedItem;
        amountReceived = receivedAmount;
        InventoryItem inventoryItem = gameObject.GetComponent<InventoryItem>();
        Type receivedItemType = Type.GetType(receivedItem);
        gameObject.AddComponent(receivedItemType);
        Item receivedItemComponent = (Item)gameObject.GetComponent(receivedItem);
        gameObject.transform.GetChild(0).GetComponent<Text>().text = receivedItemComponent.itemName; //NameText
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = receivedItemComponent.spriteList[0]; //ItemContainer -> Image
        gameObject.transform.GetChild(2).GetComponent<Text>().text = "Show Info"; //ActionText
        gameObject.transform.GetChild(3).GetComponent<Text>().text = "x " + receivedAmount; //AmountText

        foreach (KeyValuePair<string, int> req in needed)
        {
            GameObject requiredItem = Instantiate(requiredItemPrefab);

            requiredItems.Add(requiredItem);
        }

        //foreach (KeyValuePair<string, int> entry in received)
        //{
        //    if(inventoryItem.description != "")
        //    {
        //        inventoryItem.description += "\n";
        //    }
        //    inventoryItem.description += entry.Key;
        //}


        //item.transform.GetChild(1).GetComponent<Text>().text = itemType.itemName;


        /*Type seed = Type.GetType(seedType);
        currentPlant = (Plant) new GameObject(seedType).AddComponent(seed);
        currentPlant.gameObject.transform.SetParent(transform);
        currentPlant.gameObject.transform.localPosition = new Vector3(0, 0, 0);*/
    }

    public void ToggleInfo()
    {
        if (displayingInfo)
        {
            displayingInfo = false;
            gameObject.transform.GetChild(2).GetComponent<Text>().text = "Hide Info"; //ActionText
        }
        else
        {
            displayingInfo = true;
            gameObject.transform.GetChild(2).GetComponent<Text>().text = "Show Info"; //ActionText
        }
    }

    public void Fire()
    {
        TradeManager.Instance.TradeClick(gameObject);
    }
}
