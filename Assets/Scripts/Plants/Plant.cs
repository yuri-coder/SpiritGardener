using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    public int plantID, maxGrowthStage;
    public string plantName, description;
    public Dictionary<Item, int> siphonAmount;
    public Dictionary<Item, int> harvestAmount;
    protected int currentGrowthStage;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteList;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Return if plant is fully grown
    public virtual bool IsFullyGrown()
    {
        return currentGrowthStage == maxGrowthStage;
    }

    //Return the Items Siphoned and their amounts
    public virtual Dictionary<Item, int> Siphon()
    {
        return siphonAmount;
    }

    //Return the Items Harvested and their amounts
    public virtual Dictionary<Item, int> Harvest()
    {
        return harvestAmount;
    }

    //Return the current/max growth stage of the plant
    public virtual string Check()
    {
        return plantName + " - Growth Stage " + currentGrowthStage + "/" + maxGrowthStage + "\n" + description;
    }

    //Attempt to increase the growth stage of the plant
    public virtual void PlantStepUpdate()
    {
        if (currentGrowthStage < maxGrowthStage)
        {
            currentGrowthStage++;
        }
        else
        {
            print("The plant is at the max growth stage! " + currentGrowthStage + "/" + maxGrowthStage);
        }
    }
}
