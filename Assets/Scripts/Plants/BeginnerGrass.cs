using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginnerGrass : Plant {
    //protected int plantID, currentGrowthStage, maxGrowthStage;
    //protected string plantName, description;
    //protected Dictionary<Essence, int> siphonAmount;
    //protected Dictionary<Fruit, int> harvestAmount;
    //protected SpriteRenderer spriteRenderer;
    //protected List<Sprite> spriteList;

    private void Awake()
    {
        plantID = 1;
        currentGrowthStage = 1;
        maxGrowthStage = 3;
        plantName = "Beginner Grass";
        description = "A common kind of grass that all fledgling Spirit Gardeners begin their training with.";
        siphonAmount = new Dictionary<Essence, int>();
        harvestAmount = new Dictionary<Fruit, int>();
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        //spriteList = new List<Sprite>();
        //for (int i = 0; i <= 2; i++)
        //{
        //    spriteList.Add(Resources.Load<Sprite>("Sprites/Plants/BeginnerGrass_" + i));
        //}
        //spriteList.Add(Resources.Load<Sprite>("Sprites/Plants/BeginnerGrass_0"));
        //spriteList.Add(Resources.Load<Sprite>("Sprites/Plants/BeginnerGrass_1"));
        //spriteList.Add(Resources.Load<Sprite>("Sprites/Plants/BeginnerGrass_2"));
        spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/BeginnerGrass");
        //print("spriteList length = " + spriteList.Count);
        spriteRenderer.sprite = spriteList[0];
        spriteRenderer.sortingOrder = 1;
    }

    public override void PlantStepUpdate()
    {
        base.PlantStepUpdate();
        if (currentGrowthStage == 2)
            spriteRenderer.sprite = spriteList[1];
        else if (currentGrowthStage == maxGrowthStage)
            spriteRenderer.sprite = spriteList[2];
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
