using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapBuilder : MonoBehaviour
{
    [Header("Grid object")]
    public GameObject grid;

    [Header("Map to build")]
    [Tooltip("Name of map")]
    public string newMapName = "New Map";
    [Tooltip("Map handler with object holding map details")]
    public MapHandler map;

    [Header("Prefabs for tiles")]
    [Tooltip("Objects representing tiles")]
    public GameObject[] tileArray = new GameObject[0];

    [Header("Tags")]
    public string boardTag = "Board";
    public string tileTag = "Tile";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //builds the map into a grid and connects tiles
    public void BuildMap()
    {
        //if grid parent object doesn't exist, create it
        if (!grid)
        {
            SetupGrid();
        }
        //if map not null, reference the board details of map
        if (map)
        {
            List<TileBehavior> board = map.GetBoardDetails();
            //for all in map
            for(int i = 0; i < board.Count; i++)
            {
                //make sure this board object isn't null <- failsafe
                if (board[i])
                {
                    //define
                    GameObject newTile = new GameObject("Tile: " + board[i].GetWorldCoord().x + ", " + board[i].GetWorldCoord().y);
                    newTile.transform.SetParent(grid.transform);
                    //set up tile info
                    newTile.AddComponent<TileBehavior>();
                    newTile.GetComponent<TileBehavior>().CopyTileInfo(board[i]);


                    //add to board
                    grid.GetComponent<BoardManager>().boardTiles.Add(newTile.GetComponent<TileBehavior>());
                    //set the tag
                    newTile.tag = tileTag;
                }
            }
            //once done build connections
            grid.GetComponent<BoardManager>().BuildConnections();
        }
    }

    //Set up grid
    public void SetupGrid()
    {
        grid = new GameObject(newMapName);
        grid.AddComponent<Grid>();
        grid.tag = boardTag;
        if (!grid.GetComponent<BoardManager>())
        {
            BoardManager manager = grid.AddComponent<BoardManager>();
        }
        
    }
}
