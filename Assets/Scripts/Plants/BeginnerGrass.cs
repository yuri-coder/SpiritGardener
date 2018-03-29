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
    //public new static int plantID = 1;
    //public new static int maxGrowthStage = 3;
    //public new static string plantName = "Beginner Grass";
    //public new static string description = "A common kind of grass that all fledgling Spirit Gardeners begin their training with.";
    //public new static Dictionary<Essence, int> siphonAmount = new Dictionary<Essence, int>();
    //public new static Dictionary<Fruit, int> harvestAmount = new Dictionary<Fruit, int>();
    //public new static Sprite[] spriteList = Resources.LoadAll<Sprite>("Sprites/Plants/BeginnerGrass");

    private void Awake()
    {
        currentGrowthStage = 1;
        plantID = 1;
        maxGrowthStage = 3;
        plantName = "Beginner Grass";
        description = "A common kind of grass that all fledgling Spirit Gardeners begin their training with.";
        siphonAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<BasicEssence>(), 1 } };
        harvestAmount = new Dictionary<Item, int>() { { gameObject.AddComponent<BasicLeaf>(), 1} };
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
        //currentGrowthStage = TryUpdate(currentGrowthStage, maxGrowthStage);
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
