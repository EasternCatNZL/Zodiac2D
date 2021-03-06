﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour {

    [Header("Tile objects")]
    [Tooltip("Basic tile")]
    public GameObject basicTile;
    [Tooltip("Void tile")]
    public GameObject voidTile;

    [Header("Map to build")]
    [Tooltip("Name of new map")]
    public string newMapName = "New Board";
    [Tooltip("The map handler object holding the map details")]
    public MapHandler map;

    [Header("Prefabs for tiles")]
    [Tooltip("The objects used to represent the tiles")]
    public GameObject[] tileArray = new GameObject[0];

    [Header("Tags")]
    public string boardTag = "Board";
    public string tileTag = "Tile";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //builds out the map into the world
    public void BuildMap()
    {
        //if map not null, reference the board details of map
        if (map)
        {
            List<TileBehavior> board = map.GetBoardDetails();
            //create a new parent object for the new board
            GameObject newBoard = new GameObject(newMapName);
            newBoard.tag = boardTag;
            BoardManager manager = newBoard.AddComponent<BoardManager>();
            //for all objects in map
            for (int i = 0; i < board.Count; i++)
            {
                //if the current object is not null
                if (board[i])
                {
                    //define
                    GameObject newTile;
                    //create a tile of type based on coords on tile behavior object
                    switch (board[i].GetTileType())
                    {
                        case TileBehavior.TileType.Plains:
                            newTile = Instantiate(basicTile, board[i].GetWorldCoord(), Quaternion.identity);
                            newTile.transform.SetParent(newBoard.transform);
                            newTile.name = "Tile " + board[i].GetXCoord() + "," + board[i].GetYCoord();
                            newTile.GetComponent<TileBehavior>().CopyTileInfo(board[i]);
                            manager.boardTiles.Add(newTile.GetComponent<TileBehavior>());
                            //set tag
                            newTile.tag = tileTag;
                            break;
                        case TileBehavior.TileType.Road:
                            newTile = Instantiate(voidTile, board[i].GetWorldCoord(), Quaternion.identity);
                            newTile.transform.SetParent(newBoard.transform);
                            newTile.name = "Tile " + board[i].GetXCoord() + "," + board[i].GetYCoord();
                            newTile.GetComponent<TileBehavior>().CopyTileInfo(board[i]);
                            manager.boardTiles.Add(newTile.GetComponent<TileBehavior>());
                            //set tag
                            newTile.tag = tileTag;
                            break;
                        default:
                            Debug.LogWarning("There was no tile information");
                            break;
                    }
                }
            }
            //once done, build connections
            manager.BuildConnections();
        }
    }


}
