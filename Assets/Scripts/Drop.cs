using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop{

    public string name;
    public int amt;

    public Drop(string itemName, int itemAmt)
    {
        name = itemName;
        amt = itemAmt;
    }

    public Drop()
    {
        name = "BasicSeed";
        amt = 0;
    }

}
