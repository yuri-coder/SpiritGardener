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
        EnergyManager.Instance.AddEnergyOrb(curEnergy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //When restarting the game
    public void RestartGame()
    {
        maxEnergy = 5;
        EnergyManager.Instance.RestartGame();
        Start();
    }

    public void RechargeEnergy(int amount)
    {
        curEnergy = (curEnergy + amount > maxEnergy) ? maxEnergy : curEnergy + amount;
        EnergyManager.Instance.RechargeEnergy(amount);
    }

    public bool ConsumeEnergy(int amount)
    {
        if(curEnergy >= amount)
        {
            curEnergy -= amount;
            EnergyManager.Instance.ConsumeEnergy(amount);
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
        curEnergy += amount;
        EnergyManager.Instance.AddEnergyOrb(amount);
    }

    public int CurrentEnergy()
    {
        return curEnergy;
    }

}
