using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayButton : MonoBehaviour {

    public GameObject parent;
    public Sprite[] buttonSprites; //0: disabled, 1: active, 2: hovered
    public SpriteRenderer spriteRenderer;
    public bool disabled;
    public bool hovered;
    public GameplayButtonActions gameplayAction;

    //public Image[] buttonImages;

    void Awake()
    {
        disabled = false;
        hovered = false;
    }

    // Use this for initialization
    void Start () {
        SetEnabled(disabled);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ButtonEnterHover()
    {
        gameObject.GetComponent<Image>().sprite = buttonSprites[2];
    }

    public void ButtonExitHover()
    {
        gameObject.GetComponent<Image>().sprite = buttonSprites[1];
    }

    public void ButtonClick()
    {
        gameObject.GetComponent<Image>().sprite = buttonSprites[2];
        parent.SetActive(false);
        
    }


    public void SetEnabled(bool status)
    {
        disabled = status;
        if (disabled)
        {
            spriteRenderer.sprite = buttonSprites[0];
        }
        else
        {
            spriteRenderer.sprite = buttonSprites[1];
        }
    }

    private void OnMouseEnter()
    {
        print("Mouse entered " + gameplayAction);
        if (!disabled)
        {
            spriteRenderer.sprite = buttonSprites[2];
        }
        else
        {
            spriteRenderer.sprite = buttonSprites[0];
        }
    }

    private void OnMouseExit()
    {
        if (!disabled)
        {
            spriteRenderer.sprite = buttonSprites[1];
        }
        else
        {
            spriteRenderer.sprite = buttonSprites[0];
        }
    }

    private void OnMouseUpAsButton()
    {
        if(gameplayAction == GameplayButtonActions.Plant)
        {
            print("OnMouseUpAsButton Plant!");
        }
        else if(gameplayAction == GameplayButtonActions.Harvest){
            print("OnMouseUpAsButton Harvest!");
        }
        else if (gameplayAction == GameplayButtonActions.Siphon)
        {
            print("OnMouseUpAsButton Siphon!");
        }
        else if (gameplayAction == GameplayButtonActions.Check)
        {
            print("OnMouseUpAsButton Check!");
        }
        else if (gameplayAction == GameplayButtonActions.Remove)
        {
            print("OnMouseUpAsButton Remove!");
        }
    }



}
