using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaerieFlower : Plant
{
    public static Dictionary<string, bool> Harvestables = new Dictionary<string, bool>() { { "Imbued Petal", false }, { "Faerie Seed", false } };
    public static Dictionary<string, bool> Siphonables = new Dictionary<string, bool>() { { "Basic Essence", false }, { "Light Wisp", false } };

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