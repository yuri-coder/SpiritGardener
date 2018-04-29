using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaerieSeed : Seed
{

    private void Awake()
    {
        itemID = 206;
        points = 0;
        itemName = "Faerie Seed";
        description = "The seeds can often germinate with only a small amount of water needed. In comparison to other plants, however, they require much more sunlight to grow.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Seeds/FaerieSeed");
        plantType = "FaerieFlower";
    }

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
