using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {

    public int rows, columns;
    public List<GameObject> tiles;
    public List<Sprite> fieldTileSprites;
    public Dictionary<Vector2, GameObject> gameBoard = new Dictionary<Vector2, GameObject>();
    public FieldTile activeTile;
	// Use this for initialization
	void Start () {
        activeTile = null;
        BoardSetup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BoardSetup()
    {
        for(int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                print("x: " + x + ", y: " + y);
                Vector2 vlocation = new Vector2(x, y);
                GameObject instance = Instantiate(tiles[0], vlocation, Quaternion.identity, transform) as GameObject;
                Sprite sprite;
                if (x == 0 && y == 0)
                    sprite = fieldTileSprites[6];
                else if (x == rows - 1 && y == columns - 1)
                    sprite = fieldTileSprites[2];
                else if (x == 0 && y == columns - 1)
                    sprite = fieldTileSprites[0];
                else if (x == rows - 1 && y == 0)
                    sprite = fieldTileSprites[8];
                else if (y == 0)
                    sprite = fieldTileSprites[7];
                else if (y == columns - 1)
                    sprite = fieldTileSprites[1];
                else if (x == 0)
                    sprite = fieldTileSprites[3];
                else if (x == rows - 1)
                    sprite = fieldTileSprites[5];
                else
                    sprite = fieldTileSprites[4];
                instance.GetComponent<SpriteRenderer>().sprite = sprite;
                gameBoard.Add(vlocation, instance);
            }
        }
    }

    //public void StepUpdate()
    //{
    //    foreach (KeyValuePair<Vector2, GameObject> tile in gameBoard)
    //    {
    //        // do something with entry.Value or entry.Key
    //        //print("In BoardManager StepUpdate");
    //        tile.Value.SendMessage("StepUpdate");
    //    }
    //}
}
