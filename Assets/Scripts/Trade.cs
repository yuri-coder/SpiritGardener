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
    public GameObject confirmButton; //This specific Trade's confirmButton

    public GameObject requiredItemPrefab;
    public GameObject confirmButtonPrefab; //The prefab for a Trade's confirmButton
    public bool displayingInfo;

    public bool canTrade; //True if the user has enough of each required item
    public Item receivedItemComponent;

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
        displayingInfo = false;
        Type receivedItemType = Type.GetType(receivedItem);

        receivedItemComponent = (Item)new GameObject(receivedItem).AddComponent(receivedItemType);
        receivedItemComponent.gameObject.transform.SetParent(gameObject.transform);

        gameObject.transform.GetChild(0).GetComponent<Text>().text = receivedItemComponent.itemName; //NameText
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = receivedItemComponent.spriteList[0]; //ItemContainer -> Image
        gameObject.transform.GetChild(2).GetComponent<Text>().text = "Show Info"; //ActionText
        gameObject.transform.GetChild(3).GetComponent<Text>().text = "x " + receivedAmount; //AmountText

        foreach (KeyValuePair<string, int> req in needed)
        {
            //Create a required item prefab instance
            GameObject requiredItem = Instantiate(requiredItemPrefab);

            //Add Item component of the same type as the string key
            Type requiredItemType = Type.GetType(req.Key);
            requiredItem.AddComponent(requiredItemType);
            Item requiredItemComponent = (Item)requiredItem.GetComponent(req.Key);

            //Set Item Description for attached Button OnClick
            requiredItem.GetComponent<InventoryItem>().description = requiredItemComponent.description;

            TradeMaterial requiredItemTM = requiredItem.GetComponent<TradeMaterial>();
            requiredItemTM.tradeItem = requiredItemComponent;
            requiredItemTM.neededAmount = req.Value;

            requiredItem.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = requiredItemComponent.spriteList[0]; //ItemContainer -> Image
            requiredItem.transform.GetChild(1).GetComponent<Text>().text = requiredItemComponent.itemName; //NameText

            requiredItem.transform.SetParent(TradeManager.Instance.tradeObject.transform);
            requiredItem.transform.localScale = new Vector3(1, 1, 1);
            requiredItem.SetActive(false);
            requiredItems.Add(requiredItem);
        }

        confirmButton = Instantiate(confirmButtonPrefab);
        confirmButton.transform.SetParent(TradeManager.Instance.tradeObject.transform);
        confirmButton.transform.localScale = new Vector3(1, 1, 1);
        confirmButton.GetComponent<ConfirmTrade>().associatedTradeObject = gameObject;
        confirmButton.SetActive(false);
        UpdateRequiredItems();
    }

    public void UpdateRequiredItems()
    {
        bool tradeable = true;
        foreach(GameObject reqItem in requiredItems)
        {
            tradeable = SetTradeMaterialAmount(reqItem);
        }
        canTrade = tradeable;
    }

    public bool SetTradeMaterialAmount(GameObject reqItem)
    {
        int amountHeld = InventoryManager.Instance.GetItemAmount(reqItem.GetComponent<TradeMaterial>().tradeItem);
        int amountNeeded = reqItem.GetComponent<TradeMaterial>().neededAmount;
        reqItem.transform.GetChild(2).GetComponent<Text>().text = amountHeld + " / " + amountNeeded;
        if(amountHeld >= amountNeeded)
        {
            reqItem.transform.GetChild(1).GetComponent<Text>().color = InventoryManager.Instance.sufficientColor;
            reqItem.transform.GetChild(2).GetComponent<Text>().color = InventoryManager.Instance.sufficientColor;
            return true;
        }
        else
        {
            reqItem.transform.GetChild(1).GetComponent<Text>().color = InventoryManager.Instance.insufficientColor;
            reqItem.transform.GetChild(2).GetComponent<Text>().color = InventoryManager.Instance.insufficientColor;
            return false;
        }
    }

    public void ToggleInfo()
    {
        if (!displayingInfo)
        {
            displayingInfo = true;
            gameObject.transform.GetChild(2).GetComponent<Text>().text = "Hide Info"; //ActionText
        }
        else
        {
            displayingInfo = false;
            gameObject.transform.GetChild(2).GetComponent<Text>().text = "Show Info"; //ActionText
        }
    }

    public void ToggleInfo(bool toggleBool)
    {
        displayingInfo = toggleBool;
        if (displayingInfo)
        {
            gameObject.transform.GetChild(2).GetComponent<Text>().text = "Hide Info"; //ActionText
        }
        else
        {
            gameObject.transform.GetChild(2).GetComponent<Text>().text = "Show Info"; //ActionText
        }
    }

    public void Fire()
    {
        TradeManager.Instance.TradeClick(gameObject);
    }

    public void AttemptTrade()
    {
        if (canTrade)
        {
            AchievementManager.Instance.exchangeAmount += 1;
            InventoryManager.Instance.AddMultipleItems(new Dictionary<Item, int>() { { receivedItemComponent, amountReceived } });
            foreach (GameObject req in requiredItems)
            {
                TradeMaterial reqTM = req.GetComponent<TradeMaterial>();
                InventoryManager.Instance.SubtractItem(reqTM.tradeItem, reqTM.neededAmount);
            }
            foreach (GameObject trade in TradeManager.Instance.allTrades)
            {
                trade.GetComponent<Trade>().UpdateRequiredItems();
            }
        }
        else
        {
            DialogueManager.Instance.DisplayMessage("Not enough materials!");
        }
    }
}
