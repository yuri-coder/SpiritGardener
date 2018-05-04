using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FieldTile : MonoBehaviour, IPointerClickHandler {

    public Plant currentPlant; 
    public BoxCollider2D boxCollider;
    public GameObject fieldTileAnimator;
    private Animator animator;

    void Awake()
    {
        currentPlant = new GameObject("Plant").AddComponent<EmptyPlant>();
        currentPlant.transform.SetParent(transform);
        currentPlant.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(1, 1);
        currentPlant.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        animator = fieldTileAnimator.GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {}

    //Display information about the plant on click
    //private void OnMouseUpAsButton()
    //{
        
    //    if (!BoardManager.Instance.performingAction)
    //    {
    //        RadialUIManager.Instance.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    //        RadialUIManager.Instance.gameObject.SetActive(true);
    //        BoardManager boardManager = gameObject.GetComponentInParent<BoardManager>();
    //        print("Clicked FieldTile at " + transform.position);
    //        switch (InventoryManager.Instance.currentMenu)
    //        {
    //            case "PlantSeed":
    //                if (currentPlant is EmptyPlant)
    //                {

    //                    boardManager.activeTile = this;
    //                    boardManager.cursor.GetComponent<Cursor>().MoveToLocation(transform.position);
    //                    boardManager.ShowCursor();

    //                    if (boardManager.activeSeed != "")
    //                    {
    //                        ButtonManager.Instance.ConfirmSeed();
    //                    }
    //                }
    //                break;
    //            default:
    //                boardManager.activeTile = this;
    //                boardManager.cursor.GetComponent<Cursor>().MoveToLocation(transform.position);
    //                boardManager.ShowCursor();
    //                if (currentPlant is EmptyPlant)
    //                {
    //                    print("Empty plant!");
    //                    ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    //                    bm.ResetPlantButtons();
    //                    bm.EnableButton(bm.plantButton);
    //                }
    //                else if (currentPlant.IsFullyGrown())
    //                {
    //                    print("Fully grown!");
    //                    ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    //                    bm.ResetPlantButtons();
    //                    bm.EnableButton(bm.harvestButton);
    //                    bm.EnableButton(bm.siphonButton);
    //                    bm.EnableButton(bm.checkButton);
    //                }
    //                else
    //                {
    //                    print("Not fully grown!");
    //                    ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    //                    bm.ResetPlantButtons();
    //                    bm.EnableButton(bm.removeButton);
    //                    bm.EnableButton(bm.checkButton);
    //                }
    //                break;
    //        }
    //    }
        
    //}

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
        AchievementManager.Instance.siphonedAmount += 1;
        Dictionary<Item, int> siphon = currentPlant.Siphon();
        animator.SetTrigger("PlantSiphon");
        RemovePlant();
        return siphon;
    }

    //Harvest and Remove currentPlant
    public Dictionary<Item, int> HarvestPlant()
    {
        AchievementManager.Instance.harvestedAmount += 1;
        Dictionary<Item, int> harvest = currentPlant.Harvest();
        animator.SetTrigger("PlantHarvest");
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
       // if(currentPlant is BeginnerGrass)
        //{
            InventoryManager.Instance.AddMultipleItems(currentPlant.DestroyHarvest());
        //}
        Destroy(currentPlant.gameObject);
        currentPlant = new GameObject("Plant").AddComponent<EmptyPlant>();
        currentPlant.transform.SetParent(transform);
        currentPlant.gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }

    //Remove the currentPlant gameObject and make a new currentPlant gameObject with the component of the string type provided
    public void PlantFromString(string seedType)
    {
        if (AchievementManager.Instance.plantsDiscovered.Add(seedType))
        {
            InventoryManager.Instance.dialogueMessage = "Discovered a new plant!\n";
        }
        Destroy(currentPlant.gameObject);
        Type seed = Type.GetType(seedType);
        currentPlant = (Plant) new GameObject(seedType).AddComponent(seed);
        currentPlant.gameObject.transform.SetParent(transform);
        currentPlant.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        currentPlant.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        PlayerManager.Instance.SetActionState(ActionState.Plant);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //RadialUIManager.Instance.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        //RadialUIManager.Instance.gameObject.SetActive(true);
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

                    if (boardManager.activeSeed != "")
                    {
                        ButtonManager.Instance.ConfirmSeed();
                    }
                }
                break;
            default:
                if(boardManager.activeTile == this)
                {
                    RadialUIManager.Instance.gameObject.SetActive(false);
                    boardManager.activeTile = null;
                    boardManager.HideCursor();
                    return;
                }
                RadialUIManager.Instance.transform.position = Camera.main.WorldToScreenPoint(transform.position);
                RadialUIManager.Instance.gameObject.SetActive(true);
                RadialUIManager.Instance.Activate();

                boardManager.activeTile = this;
                //boardManager.cursor.transform.position = transform.position;
                boardManager.cursor.GetComponent<Cursor>().MoveToLocation(transform.position);
                //RadialUIManager.Instance.GetComponent<Cursor>().MoveToLocation(Camera.main.WorldToScreenPoint(transform.position));
                boardManager.ShowCursor();
                if (currentPlant is EmptyPlant)
                {
                    //print("Empty plant!");
                    ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
                    bm.ResetPlantButtons();
                    bm.EnableButton(bm.plantButton);
                }
                else if (currentPlant.IsFullyGrown())
                {
                    //print("Fully grown!");
                    ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
                    bm.ResetPlantButtons();
                    bm.EnableButton(bm.harvestButton);
                    bm.EnableButton(bm.siphonButton);
                    bm.EnableButton(bm.checkButton);
                }
                else
                {
                    //print("Not fully grown!");
                    ButtonManager bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
                    bm.ResetPlantButtons();
                    bm.EnableButton(bm.removeButton);
                    bm.EnableButton(bm.checkButton);
                }
                break;
        }
    }
}
