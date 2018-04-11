using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTile : MonoBehaviour {

    public Plant currentPlant; 
    public BoxCollider2D boxCollider;

    void Awake()
    {
        currentPlant = new GameObject("Plant").AddComponent<BeginnerGrass>();
        currentPlant.transform.SetParent(transform);
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(1, 1);
    }
    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {}

    //Display information about the plant on click
    private void OnMouseDown()
    {
        BoardManager boardManager = gameObject.GetComponentInParent<BoardManager>();
        print("Clicked FieldTile at " + transform.position);
        switch (InventoryManager.Instance.currentMenu)
        {
            case "PlantSeed":
                if (currentPlant is EmptyPlant)
                {
                    boardManager.activeTile = this;
                    boardManager.cursor.GetComponent<Cursor>().MoveToLocation(transform.position);
                    boardManager.ShowCursor();
                }
                break;
            default:
                boardManager.activeTile = this;
                boardManager.cursor.GetComponent<Cursor>().MoveToLocation(transform.position);
                boardManager.ShowCursor();
                if (currentPlant is EmptyPlant)
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
                break;
        }     
    }

    //Have the current plant perform its StepUpdate
    public void StepUpdate()
    {
        if (currentPlant)
        {
            currentPlant.PlantStepUpdate();
        }
        else
        {
            print("Current Plant != True");
        }
    }

    //Siphon and Remove currentPlant
    public Dictionary<Item, int> SiphonPlant()
    {
        Dictionary<Item, int> siphon = currentPlant.Siphon();
        RemovePlant();
        return siphon;
    }

    //Harvest and Remove currentPlant
    public Dictionary<Item, int> HarvestPlant()
    {
        Dictionary<Item, int> harvest = currentPlant.Harvest();
        RemovePlant();
        return harvest;
    }

    //currentPlant.Check()
    public string CheckPlant()
    {
        DialogueManager.Instance.DisplayMessage(currentPlant.Check());
        return currentPlant.Check();
    }

    //Remove the currentPlant gameObject and make a new EmptyPlant currentPlant gameObject 
    public void RemovePlant()
    {
        Destroy(currentPlant.gameObject);
        currentPlant = new GameObject("Plant").AddComponent<EmptyPlant>();
        currentPlant.transform.SetParent(transform);
        currentPlant.gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }

    //Remove the currentPlant gameObject and make a new currentPlant gameObject with the component of the string type provided
    public void PlantFromString(string seedType)
    {
        Destroy(currentPlant.gameObject);
        Type seed = Type.GetType(seedType);
        currentPlant = (Plant) new GameObject(seedType).AddComponent(seed);
        currentPlant.gameObject.transform.SetParent(transform);
        currentPlant.gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }
}
