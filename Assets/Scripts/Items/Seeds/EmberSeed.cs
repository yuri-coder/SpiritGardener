using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberSeed : Seed
{

    private void Awake()
    {
        itemID = 205;
        points = 0;
        itemName = "Ember Seed";
        description = "They have an intense liquorice scent and flavor. Wildlife commonly eat them, leading to only a small minority of seeds growing to adulthood.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Seeds/EmberSeed");
        plantType = "EmberFlower";
    }

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
