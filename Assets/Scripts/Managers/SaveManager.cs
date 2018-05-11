using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StoreThings {

    public List<SerializablePlant> currentPlants;
    ///public Dictionary<string, Dictionary<Item, int>> currentInventory;  // <-- ew ;D
    public int currentEnergy;
    public int currentMaxEnergy;
    public int currentPoints;
    public int currentTurns;

    public string GetStorableString()
    {
        return JsonConvert.SerializeObject(this);
    }

}

public class SaveManager : MonoBehaviour
{

    public static Type[] plantTypes = new Type[]
    {
        null,
        typeof(BeginnerGrass),
        typeof(FireGrass),
        typeof(WaterGrass),
        typeof(GlassBush),
        typeof(EmberFlower),
        typeof(FaerieFlower)
    };

    [RuntimeInitializeOnLoadMethod]
    static void InitializeDropTables()
    {
        
    }

    public static void Save(StoreThings thing)
    {
        File.WriteAllText("C:\\Users\\Eirika\\Desktop\\save.txt", thing.GetStorableString());
    }

    public void SaveCurrentState()
    {
        /*StoreThings toStore = new StoreThings();
        toStore.currentEnergy = PlayerManager.Instance.curEnergy;
        toStore.currentMaxEnergy = PlayerManager.Instance.maxEnergy;
        toStore.currentPoints = InventoryManager.Instance.points;
        toStore.currentTurns = InventoryManager.Instance.turns;
        toStore.currentPlants = new List<SerializablePlant>();
        foreach (KeyValuePair<Vector2, GameObject> tile in BoardManager.Instance.gameBoard)
        {
            FieldTile ftile = tile.Value.GetComponent<FieldTile>();
            toStore.currentPlants.Add(new SerializablePlant(ftile.currentPlant));
        }
        toStore.currentInventory = InventoryManager.Instance.inventory;  //O_____o
        Save(toStore);*/
        LoadSave("C:\\Users\\Eirika\\Desktop\\save.txt");
    }

    public void LoadSave(string path)
    {
        StoreThings things = Load(path);
        PlayerManager.Instance.curEnergy = things.currentEnergy;
        PlayerManager.Instance.maxEnergy = things.currentMaxEnergy;
        InventoryManager.Instance.points = things.currentPoints;
        InventoryManager.Instance.turns = things.currentTurns;
        //InventoryManager.Instance.inventory = things.currentInventory;
        int i = 0;
        foreach (KeyValuePair<Vector2, GameObject> tile in BoardManager.Instance.gameBoard)
        {
            FieldTile ftile = tile.Value.GetComponent<FieldTile>();
            if(things.currentPlants[i].plantID == 0)
            {
                ftile.ResetTile();
            }
            else
            {
                Type plantType = plantTypes[things.currentPlants[i].plantID];
                ftile.gameObject.AddComponent(plantType);
            }
            //toStore.currentPlants.Add(new SerializablePlant(ftile.currentPlant));
            i++;
        }
    }

    public static StoreThings Load(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<StoreThings>(json);
    }
}
