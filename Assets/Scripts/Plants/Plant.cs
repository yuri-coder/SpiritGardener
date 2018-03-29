using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    //public int plantID, currentGrowthStage, maxGrowthStage;
    //public string plantName, description;
    //public Dictionary<Essence, int> siphonAmount;
    //public Dictionary<Fruit, int> harvestAmount;
    protected int plantID, currentGrowthStage, maxGrowthStage;
    protected string plantName, description;
    protected Dictionary<Essence, int> siphonAmount;
    protected Dictionary<Fruit, int> harvestAmount;
    public SpriteRenderer spriteRenderer;
    //public List<Sprite> spriteList;
    public Sprite[] spriteList;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public virtual Dictionary<Essence, int> Siphon()
    {
        return siphonAmount;
    }

    public virtual Dictionary<Fruit, int> Harvest()
    {
        return harvestAmount;
    }

    public virtual string Check()
    {
        return plantName + " - Growth Stage " + currentGrowthStage + "/" + maxGrowthStage;
    }
    public virtual void PlantStepUpdate()
    {
        //print("In PlantStepUpdate");
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
