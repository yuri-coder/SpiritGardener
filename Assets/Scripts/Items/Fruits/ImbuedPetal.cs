using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImbuedPetal : Fruit
{

    private void Awake()
    {
        itemID = 6;
        points = 7;
        itemName = "Imbued Petal";
        description = "The petals are often scattered in bunches during wedding ceremonies. Because of their alluring color, they're occasionally used in desserts as well.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Fruits/ImbuedPetal");
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
