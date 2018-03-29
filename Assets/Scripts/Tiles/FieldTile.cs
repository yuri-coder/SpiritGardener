using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTile : MonoBehaviour {

    public Plant currentPlant;
    public BoxCollider2D boxCollider;
    //public GameObject curentPlant;
    //public SpriteRenderer spriteRenderer;

    void Awake()
    {
        //currentPlant = gameObject.AddComponent<BeginnerGrass>();
        currentPlant = new GameObject("Plant").AddComponent<BeginnerGrass>();
        //currentPlant.gameObject.AddComponent<SpriteRenderer>();
        currentPlant.transform.SetParent(transform);
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(1, 1);
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
        //currentPlant = new EmptyPlant();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        BoardManager boardManager = gameObject.GetComponentInParent<BoardManager>();
        boardManager.activeTile = this;
        print("Clicked FieldTile at " + transform.position);
        if(currentPlant is EmptyPlant)
        {
            print("Empty plant!");
            ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
            bm.ResetPlantButtons();
            bm.EnableButton(bm.plantButton);
        }
        else if (currentPlant.IsFullyGrown())
        {
            print("Fully grown!");
            ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
            bm.ResetPlantButtons();
            bm.EnableButton(bm.harvestButton);
            bm.EnableButton(bm.siphonButton);
            bm.EnableButton(bm.checkButton);
        }
        else
        {
            print("Not fully grown!");
            ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
            bm.ResetPlantButtons();
            bm.EnableButton(bm.removeButton);
            bm.EnableButton(bm.checkButton);
        }
    }
    public void StepUpdate()
    {
        //print("In FieldTile StepUpdate");
        if (currentPlant)
        {
            currentPlant.PlantStepUpdate();
        }
        else
        {
            print("Current Plant != True");
        }
    }

    public Dictionary<Item, int> SiphonPlant()
    {
        Dictionary<Item, int> siphon = currentPlant.Siphon();
        RemovePlant();
        return siphon;
    }

    public Dictionary<Item, int> HarvestPlant()
    {
        Dictionary<Item, int> harvest = currentPlant.Harvest();
        RemovePlant();
        return harvest;
    }

    public string CheckPlant()
    {
        return currentPlant.Check();
    }

    public void RemovePlant()
    {
        Destroy(currentPlant.gameObject);
        currentPlant = new GameObject("Plant").AddComponent<EmptyPlant>();
        currentPlant.transform.SetParent(transform);
        currentPlant.gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void TempPlant()
    {
        Destroy(currentPlant.gameObject);
        currentPlant = new GameObject("FirePlant").AddComponent<FireGrass>();
        currentPlant.gameObject.transform.SetParent(transform);
        currentPlant.gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }
}
