using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialUIManager : MonoBehaviour {

    public static RadialUIManager Instance;

    public GameObject PlantButton, HarvestButton, SiphonButton, CheckButton, RemoveButton, GrowthStage;
    public Text GrowthStageText;
    public List<GameObject> ButtonList;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
        ButtonList.Add(PlantButton);
        ButtonList.Add(HarvestButton);
        ButtonList.Add(SiphonButton);
        ButtonList.Add(CheckButton);
        ButtonList.Add(RemoveButton);
        ButtonList.Add(GrowthStage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGrowthStageText(int currentStage, int maxStage)
    {
        GrowthStageText.text = currentStage + "/" + maxStage;
    }

    //Used when setting the radil ui to be visible
    public void Activate()
    {
        foreach(GameObject button in ButtonList)
        {
            button.GetComponent<GameplayButton>().image.color = new Color32(255, 255, 255, 0);
        }
    }

}
