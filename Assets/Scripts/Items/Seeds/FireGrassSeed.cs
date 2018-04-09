using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrassSeed : Seed {

    private void Awake()
    {
        itemID = 202;
        points = 0;
        itemName = "Fire Grass Seed";
        description = "Small, warm, and smooth. Frequently used for popcorn during harvest festivals.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Seeds/FireGrassSeed");
        plantType = "FireGrass";
    }

    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {}
}
