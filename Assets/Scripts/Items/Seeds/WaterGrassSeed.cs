using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGrassSeed : Seed
{

    private void Awake()
    {
        itemID = 203;
        points = 0;
        itemName = "Water Grass Seed";
        description = "Cool and wet, with an almost slimy texture. It's less than pleasant to the touch.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Seeds/WaterGrassSeed");
        plantType = "WaterGrass";
    }

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
