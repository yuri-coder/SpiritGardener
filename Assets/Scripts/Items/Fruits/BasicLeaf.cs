﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLeaf : Fruit {

    private void Awake()
    {
        itemID = 1;
        points = 1;
        itemName = "Basic Leaf";
        description = "Soft green leaves harvested from Beginner Grass. Their abundance makes them invaluable for fledgling Spirit Gardeners training their harvesting.";
        spriteList = Resources.LoadAll<Sprite>("Sprites/Items/Fruits/BasicLeaf");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
