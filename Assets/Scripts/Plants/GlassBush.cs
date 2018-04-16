using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBush : Plant
{
    private void Awake()
    {
        currentGrowthStage = 1;
        plantID = 4;
        maxGrowthStage = 9;
        plantName = "Glass Bush";
        description = "Its branches chime in the wind as they clink together. It can take years for one to reach full maturity without the aid of spirit magic.";
        siphonAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<LightWisp>(), 0 + InventoryManager.Instance.ChanceRoll(95, 100) * 3 } };
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<CrystalBerry>(), 3 + Random.Range(0, 3) }, { gameObject.AddComponent<GlassSeed>(), 0 + InventoryManager.Instance.ChanceRoll(10, 100) * 1 } };
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/GlassBush");
        spriteRenderer.sprite = spriteList[0];
        spriteRenderer.sortingOrder = 1;
    }

    public override void PlantStepUpdate()
    {
        base.PlantStepUpdate();
        if (currentGrowthStage == 5)
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