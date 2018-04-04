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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetupInitialTrades()
    {

    }

    //When clicking on a trade to either display or hide it
    public void TradeClick(GameObject clickedTrade)
    {

    }
}
