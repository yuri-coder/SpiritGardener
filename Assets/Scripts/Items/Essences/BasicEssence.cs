using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEssence : Essence {

    //protected int itemID;
    //protected string itemName, description;
    //public new static int itemID = 101;
    //public new static string itemName = "Basic Essence";
    //public new static string description = "An inert, easily gathered essence that all fledgling Spirit Gardeners train their siphoning with.";

    private void Awake()
    {
        itemID = 101;
        itemName = "Basic Essence";
        description = "An inert, easily gathered essence that all fledgling Spirit Gardeners train their siphoning with.";
        //spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Essences/BasicEssence");
        //spriteRenderer.sprite = spriteList[0];
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
