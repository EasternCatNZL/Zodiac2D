using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public List<TileBehavior> boardTiles = new List<TileBehavior>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //builds connections between tiles once map is complete
    public void BuildConnections()
    {
        //for all the tiles
        for(int i = 0; i < boardTiles.Count; i++)
        {
            //loop through all tiles again
            for(int j = 0; j < boardTiles.Count; j++)
            {
                //check if neighbour still null, then check
                if (!boardTiles[i].neighbours.xPosTile)
                {
                    //if the currently checked against tile is the x +ve tile 
                    if(boardTiles[i].position.xPos + 1 == boardTiles[j].position.xPos
                        && boardTiles[i].position.yPos == boardTiles[j].position.yPos)
                    {
                        boardTiles[i].neighbours.xPosTile = boardTiles[j];
                    }
                }

                if (!boardTiles[i].neighbours.xNegTile)
                {
                    //if the currently checked against tile is the x -ve tile 
                    if (boardTiles[i].position.xPos - 1 == boardTiles[j].position.xPos
                        && boardTiles[i].position.yPos == boardTiles[j].position.yPos)
                    {
                        boardTiles[i].neighbours.xNegTile = boardTiles[j];
                    }
                }

                if (!boardTiles[i].neighbours.yPosTile)
                {
                    //if the currently checked against tile is the y +ve tile 
                    if (boardTiles[i].position.xPos == boardTiles[j].position.xPos
                        && boardTiles[i].position.yPos + 1 == boardTiles[j].position.yPos)
                    {
                        boardTiles[i].neighbours.yPosTile = boardTiles[j];
                    }
                }

                if (!boardTiles[i].neighbours.yPosTile)
                {
                    //if the currently checked against tile is the y -ve tile 
                    if (boardTiles[i].position.xPos == boardTiles[j].position.xPos
                        && boardTiles[i].position.yPos - 1 == boardTiles[j].position.yPos)
                    {
                        boardTiles[i].neighbours.yNegTile = boardTiles[j];
                    }
                }
            }
        }
    }
}
