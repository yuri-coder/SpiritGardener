using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrass : Plant
{
    private void Awake()
    {
        currentGrowthStage = 1;
        plantID = 2;
        maxGrowthStage = 5;
        plantName = "Fire Grass";
        description = "Its leaves are warm to the touch, and trace amounts of fire magic reside within it.";
        siphonAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<FireEssence>(), 1 + Random.Range(0, 2)} };
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<FireLeaf>(), 1 + Random.Range(0, 2) }, { gameObject.AddComponent<FireGrassSeed>(), 0 +  InventoryManager.Instance.ChanceRoll(30, 100) * 1} };
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/FireGrass");
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