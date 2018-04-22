using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour {

    public static EnergyManager Instance;

    public int MaxEnergy;
    public Sprite[] energySprites;
    public List<GameObject> energyOrbs;
    public GameObject energyOrbPrefab;

    void Awake()
    {
        Instance = this;    
    }

    // Use this for initialization
    void Start () {
        //AddEnergyOrb(5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddEnergyOrb(int amt)
    {
        for(int i = 0; i < amt; i++)
        {
            GameObject orb = Instantiate(energyOrbPrefab);
        }
    }

    public void RechargeEnergy(int amt)
    {

    }

    public void UseEnergy(int amt)
    {

    }

}
