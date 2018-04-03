using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEssence : Essence {

    private void Awake()
    {
        itemID = 102;
        itemName = "Fire Essence";
        description = "A small bundle of fiery energy. Said to be a source of heat and passion.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Essences/FireEssence");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
