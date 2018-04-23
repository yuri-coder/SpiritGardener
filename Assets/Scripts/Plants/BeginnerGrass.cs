using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginnerGrass : Plant {



    private void Awake()
    {
        currentGrowthStage = 1;
        plantID = 1;
        maxGrowthStage = 3;
        plantName = "Beginner Grass";
        description = "A common kind of grass that all fledgling Spirit Gardeners begin their training with.";
        siphonAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<BasicEssence>(), 1 + Random.Range(0, 2)}};
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<BasicLeaf>(), 1 + Random.Range(0, 2)}};
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/BeginnerGrass");
        spriteRenderer.sprite = spriteList[0];
        spriteRenderer.sortingOrder = 1;
    }

    public override void PlantStepUpdate()
    {
        base.PlantStepUpdate();
        if (currentGrowthStage == 2)
            spriteRenderer.sprite = spriteList[1];
        else if (currentGrowthStage == maxGrowthStage)
            spriteRenderer.sprite = spriteList[2];
    }

    public override Dictionary<Item, int> DestroyHarvest()
    {
        return new Dictionary<Item, int>() { { gameObject.AddComponent<BasicSeed>(), 1 } };
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
