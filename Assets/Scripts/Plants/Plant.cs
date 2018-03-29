using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    public int plantID, maxGrowthStage;
    public string plantName, description;
    public Dictionary<Item, int> siphonAmount;
    public Dictionary<Item, int> harvestAmount;

    //public static int plantID, maxGrowthStage;
    //public static string plantName, description;
    //public static Dictionary<Essence, int> siphonAmount;
    //public static Dictionary<Fruit, int> harvestAmount;
    //public static Sprite[] spriteList;
    protected int currentGrowthStage;

    //protected int plantID, currentGrowthStage, maxGrowthStage;
    //protected string plantName, description;
    //protected Dictionary<Essence, int> siphonAmount;
    //protected Dictionary<Fruit, int> harvestAmount;

    public SpriteRenderer spriteRenderer;
    //public List<Sprite> spriteList;
    public Sprite[] spriteList;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual bool IsFullyGrown()
    {
        return currentGrowthStage == maxGrowthStage;
    }

    public virtual Dictionary<Item, int> Siphon()
    {
        return siphonAmount;
    }

    public virtual Dictionary<Item, int> Harvest()
    {
        return harvestAmount;
    }

    public virtual string Check()
    {
        return plantName + " - Growth Stage " + currentGrowthStage + "/" + maxGrowthStage;
    }
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
