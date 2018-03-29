using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLeaf : Fruit {

    //protected int itemID;
    //protected string itemName, description;
    public new static int itemID = 1;
    public new static string itemName = "Basic Leaf";
    public new static string description = "Soft green leaves harvested from Beginner Grass. Their abundance makes them invaluable for fledgling Spirit Gardeners training their harvesting.";

    private void Awake()
    {
        //itemID = 1;
        //itemName = "Basic Leaf";
        //description = "Soft green leaves harvested from Beginner Grass. Their abundance makes them invaluable for fledgling Spirit Gardeners training their harvesting.";

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void addHarvestedStuff(Fruit harvestedFruit, int harvestedAmount)
    //{
    //    List<Dictionary<Type, int>> inventory = new List<Dictionary<Type, int>>();
    //    if (inventory[1].ContainsKey(harvestedFruit.GetType())){
    //        inventory[1][harvestedFruit.GetType()] += harvestedAmount;
    //    }
    //    else
    //    {
    //        inventory[1][harvestedFruit.GetType()] = harvestedAmount;
    //    }
    //}

    //public void addHarvestedStuff2(Fruit harvestedFruit, int harvestedAmount)
    //{
    //    Dictionary<Type, int> megaInventory = new Dictionary<Type, int>();
    //    if (megaInventory.ContainsKey(harvestedFruit.GetType()))
    //    {
    //        megaInventory[harvestedFruit.GetType()] += harvestedAmount;
    //    }
    //    else
    //    {
    //        megaInventory[harvestedFruit.GetType()] = harvestedAmount;
    //    }
    //}

}
