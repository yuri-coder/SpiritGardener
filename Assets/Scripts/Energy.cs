using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

    public bool full;
    private Animator animator;

    // Use this for initialization
    void Start () {
        full = true;
        animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Consume()
    {
        full = false;
        animator.SetTrigger("ConsumeEnergy");
    }

    public void Recharge()
    {
        full = true;
        animator.SetTrigger("RechargeEnergy");
    }

}
