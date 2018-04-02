using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrassSeed : Seed {

    private void Awake()
    {
        itemID = 202;
        itemName = "Fire Grass Seed";
        description = "Small, warm, and smooth. Frequently used for popcorn during harvest festivals.";
        //spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Seeds/FireGrassSeed");
        //spriteRenderer.sprite = spriteList[0];
        plantType = "FireGrass";
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
