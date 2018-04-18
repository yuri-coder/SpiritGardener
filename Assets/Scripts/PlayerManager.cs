using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    /*****************
     Static PlayerManager Instance 
     ****************/
    public static PlayerManager Instance;

    /*****************
     Player Stats
     ****************/
    public int maxEnergy;
    private int curEnergy;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
        curEnergy = maxEnergy;
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

    public void IncreaseMaxEnergy(int amount)
    {
        maxEnergy += amount;
    }

    public int CurrentEnergy()
    {
        return curEnergy;
    }

}
