using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginnerGrass : Plant {

    public static Dictionary<string, bool> Harvestables = new Dictionary<string, bool>() { { "Basic Leaf", false} };
    public static Dictionary<string, bool> Siphonables = new Dictionary<string, bool>() { { "Basic Essence", false } };


    public static DropTable averageDropTable;
    public static DropTable goodDropTable;
    public static DropTable perfectDropTable;


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

    public override string Check()
    {
        string str =  base.Check();
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
}
