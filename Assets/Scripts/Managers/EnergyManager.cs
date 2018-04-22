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
            orb.transform.SetParent(this.transform);
            orb.transform.localScale = new Vector3(1, 1, 1);
            orb.transform.SetAsFirstSibling();
            //orb.GetComponent<Energy>().Recharge();
            energyOrbs.Add(orb);
        }
    }

    public void RechargeEnergy(int amt)
    {
        int toRecharge = amt;
        int index = 0;
        while (toRecharge > 0)
        {
            if (index >= energyOrbs.Count)
            {
                print("index >= energyOrbs.Count!");
                return;
            }
            if (!energyOrbs[index].GetComponent<Energy>().full)
            {
                energyOrbs[index].GetComponent<Energy>().Recharge();
                toRecharge--;
            }
            index++;
        }
        return;
    }

    public void ConsumeEnergy(int amt)
    {
        int toConsume = amt;
        int index = 0;
        while(toConsume > 0)
        {
            if(index >= energyOrbs.Count)
            {
                print("index >= energyOrbs.Count!");
                return;
            }
            if (energyOrbs[index].GetComponent<Energy>().full)
            {
                energyOrbs[index].GetComponent<Energy>().Consume();
                toConsume--;
            }
            index++;
        }
        return;
    }

}
