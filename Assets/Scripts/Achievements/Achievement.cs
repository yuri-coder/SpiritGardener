using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Achievement : MonoBehaviour{

    public bool completed;
    public string achievementName;
    public string achievementDescription;
    public int achievementPoints;

    //Returns true if the achievement was earned, otherwise returns false
    public abstract bool TryEarnAchievement();

    public void DisplayEarnedMessage()
    {
        DialogueManager.Instance.DisplayMessage("Achievement " + achievementName + " unlocked!\n" + achievementDescription);
    }



}
