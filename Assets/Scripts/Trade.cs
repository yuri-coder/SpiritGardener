using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour {

    public Dictionary<string, int> itemsNeeded;
    public Dictionary<string, int> itemReceived;
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

    public void InitializeTrade(Dictionary<string, int> needed, Dictionary<string, int> received)
    {
        itemsNeeded = needed;
        itemReceived = received;
    }

    public void Fire()
    {
        TradeManager.Instance.TradeClick(gameObject);
    }
}
