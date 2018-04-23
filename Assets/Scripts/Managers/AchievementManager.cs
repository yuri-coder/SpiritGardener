using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

    public static AchievementManager Instance;

    public int turnsTaken;
    public int pointsEarned;
    public int inventoryWorth;
    public HashSet<string> plantsDiscovered;
    public int harvestedAmount;
    public int siphonedAmount;
    public int exchangeAmount;

    public GameObject GameScreen;
    public GameObject EndScreen;

    //public GameObject TurnsText;
    //public GameObject PointsText;
    //public GameObject TypesText;
    //public GameObject HarvestedText;
    //public GameObject SiphonedText;
    public GameObject EndingText;
    public GameObject RestartText;


    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
        ResetTexts();
        GameScreen.SetActive(true);
        EndScreen.SetActive(false);
        turnsTaken = 0;
        pointsEarned = 0;
        inventoryWorth = 0;
        plantsDiscovered = new HashSet<string>();
        harvestedAmount = 0;
        siphonedAmount = 0;
        exchangeAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
            BoardManager.Instance.RestartGame();
        }
    }

    //Called when restarting the game
    public void RestartGame()
    {
        Start();
    }

    //Called when ending the game
    public void EndGame()
    {
        GameScreen.SetActive(false);
        EndScreen.SetActive(true);
        pointsEarned = InventoryManager.Instance.points;
        turnsTaken = InventoryManager.Instance.turns;
        DisplayStats();
    }

    //Resets the UI texts
    public void ResetTexts()
    {
        //TurnsText.GetComponent<Text>().text = "";
        //PointsText.GetComponent<Text>().text = "";
        //TypesText.GetComponent<Text>().text = "";
        //HarvestedText.GetComponent<Text>().text = "";
        //SiphonedText.GetComponent<Text>().text = "";
        EndingText.GetComponent<Text>().text = "";
        RestartText.GetComponent<Text>().text = "";
    }

    //Displays various endgame stats/messages
    public void DisplayStats()
    {
        ResetTexts();
        //StartCoroutine(TurnsText.GetComponent<AutoType>().TypeText("Turns Taken: " + turnsTaken));
        //StartCoroutine(PointsText.GetComponent<AutoType>().TypeText("Points Earned: " + pointsEarned + "/" + InventoryManager.Instance.neededPoints));
        //StartCoroutine(TypesText.GetComponent<AutoType>().TypeText("Plant Types Discovered: " + plantsDiscovered.Count));
        //StartCoroutine(HarvestedText.GetComponent<AutoType>().TypeText("Total Plants Harvested: " + harvestedAmount));
        //StartCoroutine(SiphonedText.GetComponent<AutoType>().TypeText("Total Plants Siphoned: " + siphonedAmount));
        StartCoroutine(EndingText.GetComponent<AutoType>().TypeText("Turns Taken: " + turnsTaken + "\n" +
            "Points Earned: " + pointsEarned + "/" + InventoryManager.Instance.neededPoints + "\n" +
            "Plant Types Discovered: " + plantsDiscovered.Count + "\n" +
            "Total Plants Harvested: " + harvestedAmount + "\n" +
            "Total Plants Siphoned: " + siphonedAmount + "\n" +
            "Total Exchanges Made: " + exchangeAmount + "\n" +
            "Congratulations!\nYou have been recognized as an official Spirit Gardener!"));
        StartCoroutine(RestartText.GetComponent<AutoType>().TypeText("Press R to restart!"));
    }
}
