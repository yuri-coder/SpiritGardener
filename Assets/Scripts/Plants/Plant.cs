﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour {
    public int plantID, maxGrowthStage;
    public string plantName, description;
    public Dictionary<Item, int> siphonAmount;
    public Dictionary<Item, int> harvestAmount;
    public int currentGrowthStage;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteList;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetStorableString()
    {
        string toReturn = plantID + "," + currentGrowthStage;
        return toReturn;
    }

    //Return if plant is fully grown
    public virtual bool IsFullyGrown()
    {
        return currentGrowthStage == maxGrowthStage;
    }

    //Return the Items Siphoned and their amounts
    public virtual Dictionary<Item, int> Siphon()
    {
        UpdateSiphonables();
        return siphonAmount;
    }

    //Return the Items Harvested and their amounts
    public virtual Dictionary<Item, int> Harvest()
    {
        UpdateHarvestables();
        return harvestAmount;
    }

    //Return the current/max growth stage of the plant
    public virtual string Check()
    {
        return plantName + " - " + description;
    }

    //Return the Items harvested when this plant is destroyed
    public virtual Dictionary<Item, int> DestroyHarvest()
    {
        return new Dictionary<Item, int>() { };
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

    public abstract void UpdateHarvestables();

    public abstract void UpdateSiphonables();

}


public class SerializablePlant
{



    public int plantID;
    public int currentGrowthStage;

    public SerializablePlant()
    {

    }

    public SerializablePlant(Plant plant)
    {
        plantID = plant.plantID;
        currentGrowthStage = plant.currentGrowthStage;
    }
}
