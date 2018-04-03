using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Used when clicking on an item in the inventory
    public void Fire()
    {
        InventoryManager.Instance.ItemClick(gameObject);
    }
}
