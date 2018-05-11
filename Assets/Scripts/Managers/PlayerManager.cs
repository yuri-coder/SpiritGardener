using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    /*****************
     Static PlayerManager Instance 
     ****************/
    public static PlayerManager Instance;


    /*****************
     Other Globals 
     ****************/
    public float wandCycleSpeed;
    public float wandAnimationCycleSpeed;
    public float charJumpSpeed;
    public float charJumpAmount;

    /*****************
     Player Stats
     ****************/
    public int maxEnergy;
    public int curEnergy;

    /*****************
     Character Related
     ****************/
    public GameObject character;
    //public Vector3 characterOriginalPosition;
    //public Vector3 characterMoveToPosition;
    public Sprite[] characterSprites;
    public SpriteRenderer charRenderer;

    /*****************
     Wand Related
     ****************/
    public GameObject wand;
    public Sprite[] wandSprites;
    public SpriteRenderer wandRenderer;

    /*****************
     States/Offsets
     ****************/
    public ActionState currentState;
    public int wandBase;
    public float wandCycleTimer;
    public float wandAnimationTimer;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
        curEnergy = maxEnergy;
        EnergyManager.Instance.AddEnergyOrb(curEnergy);
        wandBase = 0;
        wandCycleTimer = 0f;
        wandAnimationTimer = 0f;
        //wandCycleSpeed = 1.0f;
        //wandAnimationCycleSpeed = 2.0f;
        //characterOriginalPosition = new Vector3(0, 0, 0);
        SetActionState(ActionState.None);
	}
	
	// Update is called once per frame
	void Update () {  
        wandCycleTimer += Time.deltaTime;
        if(wandCycleTimer >= wandCycleSpeed)
        {
            wandCycleTimer = 0f;
            wandBase = (wandBase + 1) % 2;
        }
        if(currentState != ActionState.None)
        {
            wandAnimationTimer += Time.deltaTime;
            if(wandAnimationTimer >= wandAnimationCycleSpeed)
            {
                SetActionState(ActionState.None);
            }
        }
        wandRenderer.sprite = wandSprites[wandBase + (2 * (int) currentState)];
    }

    public void SetActionState(ActionState newState)
    {
        currentState = newState;
        wandAnimationTimer = 0f;
        if(currentState == ActionState.None)
        {
            charRenderer.sprite = characterSprites[1];
        }
        else if(currentState == ActionState.Harvest || currentState == ActionState.Siphon || currentState == ActionState.Plant)
        {
            charRenderer.sprite = characterSprites[0];
        }
        else if(currentState == ActionState.Insufficient)
        {
            charRenderer.sprite = characterSprites[Random.Range(0, 2) + 2];
        }
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
            SetActionState(ActionState.Insufficient);
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
