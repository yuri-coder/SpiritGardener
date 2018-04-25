﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberFlower : Plant
{
    private void Awake()
    {
        currentGrowthStage = 1;
        plantID = 5;
        maxGrowthStage = 3;
        plantName = "Ember Flower";
        description = "In lieu of barbs or thorns, the entire plant is poisonous, and ingesting one can lead to severe dehydration and nausea.";

        Drop shared1 = new Drop("FireEssence", Random.Range(1, 4));
        Drop shared2 = new Drop("SmokeWisp", Random.Range(1, 3));
        Drop sharedDrop = InventoryManager.Instance.SharedChanceRoll(new Dictionary<Drop, int>() { { shared1, 25 }, { shared2, 75 } }, 100);

        siphonAmount = new Dictionary<Item, int>() { {(Item) gameObject.AddComponent(System.Type.GetType(sharedDrop.name)), sharedDrop.amt } };
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<SmoulderingPetal>(), 2 + Random.Range(0, 2) }, { gameObject.AddComponent<EmberSeed>(), 0 + InventoryManager.Instance.ChanceRoll(10, 100) * 1 } };
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/EmberFlower");
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}