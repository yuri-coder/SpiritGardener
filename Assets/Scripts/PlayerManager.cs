using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int maxEnergy;
    private int curEnergy;

    void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RechargeEnergy(int amount)
    {
        curEnergy = (curEnergy + amount > maxEnergy) ? maxEnergy : curEnergy + amount;
    }

    public bool ConsumeEnergy(int amount)
    {
        if(curEnergy >= amount)
        {
            curEnergy -= amount;
            return true;
        }
        else
        {
            DialogueManager.Instance.DisplayMessage("Not enough energy remaining!");
            return false;
        }
    }

    public int CurrentEnergy()
    {
        return curEnergy;
    }

}
