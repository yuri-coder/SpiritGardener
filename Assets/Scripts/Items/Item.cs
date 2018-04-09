using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    /*****************
     Variables
     ****************/
    public int itemID, points;
    public string itemName, description;
    public Sprite[] spriteList;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Return the item name and description together
    public virtual string Info()
    {
        return itemName + " - " + description;
    }
}
