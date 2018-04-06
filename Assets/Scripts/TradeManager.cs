using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager : MonoBehaviour {

    public static TradeManager Instance;
    public GameObject tradeObject; //Exchange -> General
    public GameObject tradePrefab;

    public List<GameObject> allTrades;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        SetupInitialTrades();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetupInitialTrades()
    {
        print("Starting SetupInitialTrades");
        CreateTrade(new Dictionary<string, int>() { { "BasicLeaf", 1 }, { "BasicEssence", 2 } }, "FireGrassSeed", 1);
        CreateTrade(new Dictionary<string, int>() { { "BasicLeaf", 2 }, { "FireLeaf", 1 } }, "FireGrassSeed", 3);
        CreateTrade(new Dictionary<string, int>() { { "BasicLeaf", 2 }, { "FireLeaf", 1 }, { "FireEssence", 2} }, "FireGrassSeed", 4);
        HideAllTradeInfo();
        print("Finishing SetupInitialTrades");
    }

    //When clicking on a trade to either display or hide it
    public void TradeClick(GameObject clickedTrade)
    {
        Trade trade = clickedTrade.GetComponent<Trade>();
        trade.UpdateRequiredItems();
        foreach (GameObject req in trade.requiredItems){
            req.SetActive(!req.activeInHierarchy);
        }
        trade.confirmButton.SetActive(!trade.confirmButton.activeInHierarchy);
        trade.ToggleInfo();
    }

    public void CreateTrade(Dictionary<string, int> needed, string receivedName, int receivedAmount)
    {
        print("Starting CreateTrade");
        GameObject trade = Instantiate(tradePrefab);
        trade.transform.SetParent(tradeObject.transform);
        trade.transform.localScale = new Vector3(1, 1, 1);
        trade.GetComponent<Trade>().InitializeTrade(needed, receivedName, receivedAmount);
        allTrades.Add(trade);
        print("Finishing CreateTrade");
    }

    public void HideAllTradeInfo()
    {
        print("In hide all trade info");
        foreach (GameObject trade in allTrades)
        {
            print("In for each loop");
            //GameObject trade = tradeTransform.gameObject;
            trade.SetActive(true);
            Trade tradeComponent = trade.GetComponent<Trade>();
            foreach (GameObject req in tradeComponent.requiredItems)
            {
                req.SetActive(false);
            }
            tradeComponent.confirmButton.SetActive(false);
            tradeComponent.ToggleInfo(false);
        }
    }
}
