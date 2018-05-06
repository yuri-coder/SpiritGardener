using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrass : Plant
{
    public static Dictionary<string, bool> Harvestables = new Dictionary<string, bool>() { { "Fire Leaf", false }, { "Fire Grass Seed", false } };
    public static Dictionary<string, bool> Siphonables = new Dictionary<string, bool>() { { "Fire Essence", false } };

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