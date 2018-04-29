using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaerieFlower : Plant
{
    private void Awake()
    {
        currentGrowthStage = 1;
        plantID = 6;
        maxGrowthStage = 4;
        plantName = "Faerie Flower";
        description = "It sparkles in the daylight, making it a popular pick for spring gardens. It has a sweet, pleasant aroma as well.";

        Drop shared1 = new Drop("BasicEssence", Random.Range(3, 6));
        Drop shared2 = new Drop("LightWisp", Random.Range(2, 5));
        Drop sharedDrop = InventoryManager.Instance.SharedChanceRoll(new Dictionary<Drop, int>() { { shared1, 15 }, { shared2, 85 } }, 100);

        siphonAmount = new Dictionary<Item, int>() { { (Item)gameObject.AddComponent(System.Type.GetType(sharedDrop.name)), sharedDrop.amt } };
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<ImbuedPetal>(), 2 + Random.Range(0, 3) }, { gameObject.AddComponent<FaerieSeed>(), 0 + InventoryManager.Instance.ChanceRoll(10, 100) * 1 } };
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/FaerieFlower");
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