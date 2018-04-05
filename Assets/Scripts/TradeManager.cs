using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager : MonoBehaviour {

    public static TradeManager Instance;
    public GameObject tradeObject; //The entire Inventory GameObject (with General, etc.)
    public GameObject tradePrefab;

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
        CreateTrade(new Dictionary<string, int>() { { "BeginnerLeaf", 1 }, { "BasicEssence", 2 } }, "FireGrassSeed", 1);
    }

    //When clicking on a trade to either display or hide it
    public void TradeClick(GameObject clickedTrade)
    {
        Trade trade = clickedTrade.GetComponent<Trade>();
        foreach (GameObject req in trade.requiredItems){
            req.SetActive(!req.activeInHierarchy);
        }
        trade.confirmButton.SetActive(!trade.confirmButton.activeInHierarchy);
        trade.ToggleInfo();
    }

    public void CreateTrade(Dictionary<string, int> needed, string receivedName, int receivedAmount)
    {
        GameObject trade = Instantiate(tradePrefab);
        trade.transform.SetParent(tradeObject.transform);
        trade.GetComponent<Trade>().InitializeTrade(needed, receivedName, receivedAmount);
    }
}
