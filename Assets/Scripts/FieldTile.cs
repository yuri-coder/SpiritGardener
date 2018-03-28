using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTile : MonoBehaviour {

    public Plant currentPlant;

    void Awake()
    {
        currentPlant = gameObject.AddComponent<EmptyPlant>();
    }
    // Use this for initialization
    void Start () {
        //currentPlant = new EmptyPlant();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StepUpdate()
    {
        print("In FieldTile StepUpdate");
        if (currentPlant)
        {
            currentPlant.PlantStepUpdate();
        }
        else
        {
            print("Current Plant != True");
        }
    }

    public Dictionary<Essence, int> SiphonPlant()
    {
        return currentPlant.Siphon();
    }

    public Dictionary<Fruit, int> HarvestFruit()
    {
        return currentPlant.Harvest();
    }

    public string checkPlant()
    {
        return currentPlant.Check();
    }

    public void RemovePlant()
    {
        Destroy(currentPlant);
        currentPlant = new EmptyPlant();
    }
}
