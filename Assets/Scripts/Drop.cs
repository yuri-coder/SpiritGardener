using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop{

    public string name;
    public int maxAmt;
    public int minAmt;

    public Drop(string itemName, int max)
    {
        name = itemName;
        maxAmt = max;
        minAmt = max;
    }

    public Drop()
    {
        name = "BasicSeed";
        maxAmt = 0;
        minAmt = 0;
    }

    public Drop(string itemName, int min, int max)
    {
        name = itemName;
        minAmt = min;
        maxAmt = max;
    }

}
