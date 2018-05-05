using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialUIManager : MonoBehaviour {

    public static RadialUIManager Instance;

    public GameplayButton PlantButton, HarvestButton, SiphonButton, CheckButton, RemoveButton, GrowthStage;
    public Text GrowthStageText;
    public List<GameplayButton> ButtonList;

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
        gameObject.SetActive(true);
        foreach(GameplayButton button in ButtonList)
        {
            button.image.color = new Color32(255, 255, 255, 0);
        }
    }

    public void DisableAllButtons()
    {
        foreach (GameplayButton button in ButtonList)
        {
            button.SetEnabled(false);
        }
    }

    public void EnableAllButtons()
    {
        foreach (GameplayButton button in ButtonList)
        {
            button.SetEnabled(true);
        }
    }

    //For when there is no plant in the square
    public void EmptyPlantInterface()
    {
        DisableAllButtons();
        PlantButton.SetEnabled(true);
        GrowthStage.gameObject.SetActive(false);
    }

    //For when a plant is still growing
    public void NotFullyGrownInterface()
    {
        DisableAllButtons();
        CheckButton.SetEnabled(true);
        RemoveButton.SetEnabled(true);
        GrowthStage.gameObject.SetActive(true);
        GrowthStage.SetEnabled(true);
    }

    //For when a plant is fully grown
    public void FullyGrownInterface()
    {
        DisableAllButtons();
        HarvestButton.SetEnabled(true);
        SiphonButton.SetEnabled(true);
        CheckButton.SetEnabled(true);
        GrowthStage.gameObject.SetActive(true);
        GrowthStage.SetEnabled(true);
    }

}
