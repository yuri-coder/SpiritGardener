using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable {

    public List<Dictionary<Drop, int>> dropSlots;

    public DropTable()
    {
        dropSlots = new List<Dictionary<Drop, int>>();
    }

    public List<Drop> RollTable()
    {
        List<Drop> drops = new List<Drop>();
        foreach(Dictionary<Drop, int> dropSlot in dropSlots)
        {
            drops.Add(InventoryManager.Instance.SharedChanceRoll(dropSlot));
        }
        return drops;
    }
}
