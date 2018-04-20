using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeWisp : Essence
{

    private void Awake()
    {
        itemID = 105;
        points = 3;
        itemName = "Smoke Wisp";
        description = "Ephemeral and hard to contain. More often than not, only its remnants can be found, usually in the form of accumulated soot on leaves.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Essences/SmokeWisp");
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
