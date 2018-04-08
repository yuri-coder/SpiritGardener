using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEssence : Essence
{

    private void Awake()
    {
        itemID = 103;
        itemName = "Water Essence";
        description = "A small bundle of water energy. Despite its name, it retains the flame-like appearance common to most common essences.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Essences/WaterEssence");
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
