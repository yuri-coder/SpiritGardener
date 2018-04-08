using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLeaf : Fruit
{

    private void Awake()
    {
        itemID = 3;
        itemName = "Water Leaf";
        description = "More often used for medicinal purposes as opposed to culinary ones. A staple for all first aid kits.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Fruits/WaterLeaf");
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
