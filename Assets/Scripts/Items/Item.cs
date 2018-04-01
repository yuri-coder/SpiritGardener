using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    public int itemID;
    public string itemName, description;
    //public SpriteRenderer spriteRenderer;
    public Sprite[] spriteList;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual string Info()
    {
        return itemName + " - " + description;
    }
}
