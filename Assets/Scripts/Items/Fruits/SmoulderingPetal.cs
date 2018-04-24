using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoulderingPetal : Fruit
{

    private void Awake()
    {
        itemID = 5;
        points = 4;
        itemName = "Smouldering Petal";
        description = "Over time, the vibrant reds fade to black like the rest of the plant. The petals are occasionally scattered during funeral processions.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Fruits/SmoulderingPetal");
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
