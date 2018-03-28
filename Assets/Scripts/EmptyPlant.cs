using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPlant : Plant {
    //protected int plantID, currentGrowthStage, maxGrowthStage;
    //protected string plantName, description;
    //protected Dictionary<Essence, int> siphonAmount;
    //protected Dictionary<Fruit, int> harvestAmount;

    void Awake()
    {
        plantID = 0;
        currentGrowthStage = 0;
        maxGrowthStage = 0;
        plantName = "Empty Plant";
        description = "Empty Plant";
        siphonAmount = new Dictionary<Essence, int>();
        harvestAmount = new Dictionary<Fruit, int>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
