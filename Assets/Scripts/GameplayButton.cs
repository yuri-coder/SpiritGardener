using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameplayButton : MonoBehaviour {

    public GameObject parent;
    public Sprite[] buttonSprites; //0: disabled, 1: active, 2: hovered
    public Image image;
    //public SpriteRenderer spriteRenderer;
    public bool disabled;
    public bool hovered;
    public GameplayButtonActions gameplayAction;


    //public Image[] buttonImages;

    void Awake()
    {
        disabled = false;
        hovered = false;
        //var screenPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Use this for initialization
    void Start () {
        SetEnabled(disabled);
	}
	
	// Update is called once per frame
	void Update () {
		image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (2.5f * Time.deltaTime));
    }


    public void ButtonEnterHover()
    {
        if(!disabled)
            gameObject.GetComponent<Image>().sprite = buttonSprites[2];
        else
            gameObject.GetComponent<Image>().sprite = buttonSprites[0];
    }

    public void ButtonExitHover()
    {
        if(!disabled)
            gameObject.GetComponent<Image>().sprite = buttonSprites[1];
        else
            gameObject.GetComponent<Image>().sprite = buttonSprites[0];
    }

    //public void ButtonClick(BaseEventData bed)
    //{
    //    PointerEventData ped = (PointerEventData)bed;
    //    //-1 = LMB, -2 = RMB, -3 = MMB
    //    //Debug.Log("Button: " + ped.pointerId);

    //    //Left Mouse Click
    //    if(ped.pointerId == -1)
    //    {

    //    }
    //    //Right Mouse Click
    //    else if(ped.pointerId == -2)
    //    {

    //    }

    //    gameObject.GetComponent<Image>().sprite = buttonSprites[2];
    //    //parent.SetActive(false);
        
    //}

    public void ButtonClick()
    {
        print("Before setting BoardManager.Instance.performingAction to true");
        //BoardManager.Instance.performingAction = true;
        print("Set BoardManager.Instance.performingAction to true");
        gameObject.GetComponent<Image>().sprite = buttonSprites[2];
        parent.SetActive(false);
    }


    public void SetEnabled(bool status)
    {
        disabled = status;
        if (disabled)
        {
            gameObject.GetComponent<Image>().sprite = buttonSprites[0];
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = buttonSprites[1];
        }
    }

    //private void OnMouseEnter()
    //{
    //    print("Mouse entered " + gameplayAction);
    //    if (!disabled)
    //    {
    //        gameObject.GetComponent<Image>().sprite = buttonSprites[2];
    //    }
    //    else
    //    {
    //        gameObject.GetComponent<Image>().sprite = buttonSprites[0];
    //    }
    //}

    //private void OnMouseExit()
    //{
    //    if (!disabled)
    //    {
    //        gameObject.GetComponent<Image>().sprite = buttonSprites[1];
    //    }
    //    else
    //    {
    //        gameObject.GetComponent<Image>().sprite = buttonSprites[0];
    //    }
    //}

    //private void OnMouseUpAsButton()
    //{
    //    if(gameplayAction == GameplayButtonActions.Plant)
    //    {
    //        print("OnMouseUpAsButton Plant!");
    //    }
    //    else if(gameplayAction == GameplayButtonActions.Harvest){
    //        print("OnMouseUpAsButton Harvest!");
    //    }
    //    else if (gameplayAction == GameplayButtonActions.Siphon)
    //    {
    //        print("OnMouseUpAsButton Siphon!");
    //    }
    //    else if (gameplayAction == GameplayButtonActions.Check)
    //    {
    //        print("OnMouseUpAsButton Check!");
    //    }
    //    else if (gameplayAction == GameplayButtonActions.Remove)
    //    {
    //        print("OnMouseUpAsButton Remove!");
    //    }
    //}
}
