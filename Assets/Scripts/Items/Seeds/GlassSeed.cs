using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSeed : Seed
{

    private void Awake()
    {
        itemID = 204;
        points = 0;
        itemName = "Glass Seed";
        description = "Extremely hard, but prone to shattering. It grows best in cold environments, taking a long time to reach maturity.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Seeds/GlassSeed");
        plantType = "GlassBush";
    }

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
