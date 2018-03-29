using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPlant : Plant {
    void Awake()
    {
        currentGrowthStage = 0;
        plantID = 0;
        maxGrowthStage = 0;
        plantName = "Empty Plant";
        description = "Empty Plant";
        siphonAmount = new Dictionary<Essence, int>();
        harvestAmount = new Dictionary<Fruit, int>();
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;
        //spriteRenderer.sortingOrder = 1;
    }

    public override void PlantStepUpdate()
    {
        print("Overriding! Empty plants can't update.");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
