using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {

    /*****************
     Static Board Instance
     ****************/
    public static BoardManager Instance;

    /*****************
     Board Constraints
     ****************/
    public int rows, columns;

    /*****************
     Other Board Setup
     ****************/
    public List<GameObject> tiles; //Prefab with FieldTile script
    public List<Sprite> fieldTileSprites; //List of various fieldTiles
    public Dictionary<Vector2, GameObject> gameBoard = new Dictionary<Vector2, GameObject>(); //Virtual representation of the GameBoard
    public GameObject cursor; //Cursor showing where the user has clicked

    /*****************
     Navigation/History Related Variables
     ****************/
    public FieldTile activeTile;
    public string activeSeed;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        activeTile = null;
        BoardSetup();
        HideCursor();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Sets up the GameBoard grid with empty FieldTiles
    void BoardSetup()
    {
        for(int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                //print("x: " + x + ", y: " + y);
                Vector2 vlocation = new Vector2(x, y);
                GameObject instance = Instantiate(tiles[0], vlocation, Quaternion.identity, transform) as GameObject;
                Sprite sprite;
                if (x == 0 && y == 0)
                    sprite = fieldTileSprites[6];
                else if (x == columns - 1 && y == rows - 1)
                    sprite = fieldTileSprites[2];
                else if (x == 0 && y == rows - 1)
                    sprite = fieldTileSprites[0];
                else if (x == columns - 1 && y == 0)
                    sprite = fieldTileSprites[8];
                else if (y == 0)
                    sprite = fieldTileSprites[7];
                else if (y == rows - 1)
                    sprite = fieldTileSprites[1];
                else if (x == 0)
                    sprite = fieldTileSprites[3];
                else if (x == columns - 1)
                    sprite = fieldTileSprites[5];
                else
                    sprite = fieldTileSprites[4];
                instance.GetComponent<SpriteRenderer>().sprite = sprite;
                gameBoard.Add(vlocation, instance);
            }
        }
    }

    //Hides/Shows Cursor
    public void ShowCursor()
    {
        cursor.SetActive(true);
    }

    public void HideCursor()
    {
        cursor.SetActive(false);
    }

    //Toggles Cursor
    public void ToggleCursor()
    {
        cursor.SetActive(!cursor.activeInHierarchy);
    }
}
