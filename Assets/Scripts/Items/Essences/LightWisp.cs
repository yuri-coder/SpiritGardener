using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWisp : Essence
{

    private void Awake()
    {
        itemID = 104;
        points = 3;
        itemName = "Light Wisp";
        description = "It glows faintly in relaxing pulse of light. Its luminescence fades over time, eventually turning into Basic Essence once its energy has run out.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Essences/LightWisp");
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
