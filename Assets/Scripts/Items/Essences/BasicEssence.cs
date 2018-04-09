using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEssence : Essence {

    private void Awake()
    {
        itemID = 101;
        points = 1;
        itemName = "Basic Essence";
        description = "An inert, easily gathered essence that all fledgling Spirit Gardeners train their siphoning with.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Essences/BasicEssence");
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
