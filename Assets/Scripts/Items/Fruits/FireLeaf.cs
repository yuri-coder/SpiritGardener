using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLeaf : Fruit {

    private void Awake()
    {
        itemID = 2;
        itemName = "Fire Leaf";
        description = "Once harvested, the leaves cool down. Some use it as a cooking ingredient, but it's quite bitter.";
        //spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Fruits/FireLeaf");
        //spriteRenderer.sprite = spriteList[0];
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
