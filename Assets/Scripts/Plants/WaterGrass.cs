using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGrass : Plant
{

    public static Dictionary<string, bool> Harvestables = new Dictionary<string, bool>() { { "Water Leaf", false }, { "Water Grass Seed", false } };
    public static Dictionary<string, bool> Siphonables = new Dictionary<string, bool>() { { "Water Essence", false } };

    private void Awake()
    {
        currentGrowthStage = 1;
        plantID = 3;
        maxGrowthStage = 6;
        plantName = "Water Grass";
        description = "Typically found near ponds and lakes. Along with Fire and Beginner Grass, it's one of the three most commonly used plants for training.";
        siphonAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<WaterEssence>(), 1 + Random.Range(0, 2) } };
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<WaterLeaf>(), 1 + Random.Range(0, 2) }, { gameObject.AddComponent<WaterGrassSeed>(), 0 + InventoryManager.Instance.ChanceRoll(25, 100) * 1 } };
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

    public override string Check()
    {
        string str = base.Check();
        str += "\nHarvestable: ";

        string harvests = "";
        foreach (KeyValuePair<string, bool> entry in Harvestables)
        {
            if (entry.Value)
            {
                harvests += entry.Key + ", ";
            }
            else
            {
                harvests += "???, ";
            }
        }

        str += harvests.Remove(harvests.Length - 2, 2) + "\nSiphonable: ";

        string siphons = "";
        foreach (KeyValuePair<string, bool> entry in Siphonables)
        {
            if (entry.Value)
            {
                siphons += entry.Key + ", ";
            }
            else
            {
                siphons += "???, ";
            }
        }

        str += siphons.Remove(siphons.Length - 2, 2);

        return str;
    }

    public override void UpdateHarvestables()
    {
        foreach (KeyValuePair<Item, int> entry in harvestAmount)
        {
            if (entry.Value > 0)
            {
                bool discovered = false;
                if (Harvestables.TryGetValue(entry.Key.itemName, out discovered))
                {
                    if (!discovered)
                    {
                        Harvestables[entry.Key.itemName] = true;
                    }
                }
                else
                {
                    print(entry.Key.itemName + " not found in the list of Harvestables!");
                }
            }
        }
    }

    public override void UpdateSiphonables()
    {
        foreach (KeyValuePair<Item, int> entry in siphonAmount)
        {
            if (entry.Value > 0)
            {
                bool discovered = false;
                if (Siphonables.TryGetValue(entry.Key.itemName, out discovered))
                {
                    if (!discovered)
                    {
                        Siphonables[entry.Key.itemName] = true;
                    }
                }
                else
                {
                    print(entry.Key.itemName + " not found in the list of Siphonables!");
                }
            }
        }
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