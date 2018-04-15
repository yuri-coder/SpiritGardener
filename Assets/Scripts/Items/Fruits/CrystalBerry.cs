using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBerry : Fruit
{

    private void Awake()
    {
        itemID = 4;
        points = 4;
        itemName = "Crystal Berry";
        description = "Hard and inedible until cooked. It derives its name from its glass-like appearance.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Fruits/CrystalBerry");
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
