using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGrass : Plant
{
    private void Awake()
    {
        currentGrowthStage = 1;
        plantID = 3;
        maxGrowthStage = 6;
        plantName = "Water Grass";
        description = "Typically found near ponds and lakes. Along with Fire and Beginner Grass, it's one of the three most commonly used plants for training.";
        siphonAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<WaterEssence>(), 1 + Random.Range(0, 2) } };
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<WaterLeaf>(), 1 + Random.Range(0, 2) }, { gameObject.AddComponent<WaterGrassSeed>(), 0 + InventoryManager.Instance.ChanceRoll(80, 100) * 1 } };
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/WaterGrass");
        spriteRenderer.sprite = spriteList[0];
        spriteRenderer.sortingOrder = 1;
    }

    public override void PlantStepUpdate()
    {
        base.PlantStepUpdate();
        if (currentGrowthStage == 3)
            spriteRenderer.sprite = spriteList[1];
        else if (currentGrowthStage == maxGrowthStage)
            spriteRenderer.sprite = spriteList[2];
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}