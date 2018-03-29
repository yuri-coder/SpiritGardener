using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLeaf : Fruit {

    //protected int itemID;
    //protected string itemName, description;

    private void Awake()
    {
        itemID = 1;
        itemName = "Basic Leaf";
        description = "Soft green leaves harvested from Beginner Grass. Their abundance makes them invaluable for fledgling Spirit Gardeners training their harvesting.";

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
