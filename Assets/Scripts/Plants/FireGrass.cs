using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrass : Plant
{
    //public new static int plantID = 2;
    //public new static int maxGrowthStage = 5;
    //public new static string plantName = "Fire Grass";
    //public new static string description = "Its leaves are warm to the touch, and trace amounts of fire magic reside within it.";
    //public new static Dictionary<Essence, int> siphonAmount = new Dictionary<Essence, int>();
    //public new static Dictionary<Fruit, int> harvestAmount = new Dictionary<Fruit, int>();

    private void Awake()
    {
        currentGrowthStage = 1;
        //spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        //spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/FireGrass");
        //spriteRenderer.sprite = spriteList[0];
        //spriteRenderer.sortingOrder = 1;

        plantID = 2;
        maxGrowthStage = 5;
        plantName = "Fire Grass";
        description = "Its leaves are warm to the touch, and trace amounts of fire magic reside within it.";
        siphonAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<FireEssence>(), 1 } };
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<FireLeaf>(), 1 } };
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        //spriteList = new List<Sprite>();
        //for (int i = 0; i <= 2; i++)
        //{
        //    spriteList.Add(Resources.Load<Sprite>("Sprites/Plants/BeginnerGrass_" + i));
        //}
        //spriteList.Add(Resources.Load<Sprite>("Sprites/Plants/BeginnerGrass_0"));
        //spriteList.Add(Resources.Load<Sprite>("Sprites/Plants/BeginnerGrass_1"));
        //spriteList.Add(Resources.Load<Sprite>("Sprites/Plants/BeginnerGrass_2"));
        spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/FireGrass");
        //print("spriteList length = " + spriteList.Count);
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


//public class Inventory
//{
//    public Dictionary<Item, int> Items = new Dictionary<Item, int>();

//    public void AddItemToInventory(Item itemToAdd, int amount)
//    {
//        foreach (KeyValuePair<Item, int> entry in Items)
//        {
//            if(entry.Key.GetType() == itemToAdd.GetType())
//            {
//                Items[entry.Key] += amount;
//                return;
//            }
//        }
//        Items.Add(itemToAdd, amount);
//    }

//    public void RemoveItemOfTypeFromInventory<T>() where T : Item
//    {
//        if (Items.Contains(T))
//        {
//            Items[T]--;
//            if (Items[T] < 0)
//                Items[T] = 0;
//        }
//    }

//    public int GetNumOfItemsOfType<T>() where T : Item
//    {
//        if (Items.Contains(T))
//        {
//            return Items[T];
//        }
//        else
//        {
//            return 0;
//        }
//    }
//}
