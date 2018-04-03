using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSeed : Seed
{

    private void Awake()
    {
        itemID = 201;
        itemName = "Basic Seed";
        description = "A small miracle of life! Grows into Beginner Grass.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Seeds/BasicSeed");
        plantType = "BeginnerGrass";
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
