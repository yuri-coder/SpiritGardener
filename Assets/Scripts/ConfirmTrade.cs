using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmTrade : MonoBehaviour {

    public GameObject associatedTradeObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
    {
        if (associatedTradeObject)
            associatedTradeObject.GetComponent<Trade>().AttemptTrade();
        else
            print("No associated trade object");
    }
}
