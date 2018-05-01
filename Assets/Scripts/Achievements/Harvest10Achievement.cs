using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest10Achievement : Achievement {

	// Use this for initialization
	void Start () {
        achievementName = "Beginner Harvester";
        achievementDescription = "Harvest 10 plants!";
        achievementPoints = 10;
        completed = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override bool TryEarnAchievement()
    {
        if (completed)
        {
            return false;
        }
        if(AchievementManager.Instance.harvestedAmount >= 10)
        {
            DisplayEarnedMessage();
            completed = true;
            return true;
        }
        return false;
    }

    
}
