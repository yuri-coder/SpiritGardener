using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade {

    public Dictionary<Item, int> itemsNeeded;
    public Dictionary<Item, int> itemsReceived;
    public string tradeName;

    public Trade(Dictionary<Item, int> needed, Dictionary<Item, int> received, string name)
    {
        itemsNeeded = needed;
        itemsReceived = received;
        tradeName = name;
    }

    public Trade(Dictionary<Item, int> needed, Dictionary<Item, int> received)
    {
        itemsNeeded = needed;
        itemsReceived = received;
        tradeName = "";
    }

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}
