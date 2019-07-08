using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInit : MonoBehaviour
{
    [Header("Tags")]
    public string tileTag = "Tile";

    [Header("Script refs")]
    public GameControl control;

    // Start is called before the first frame update
    void Start()
    {
        FindBases();
        FindBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //find all the bases when map starts
    private void FindBases()
    {
        //get the tiles
        GameObject[] allTiles = GameObject.FindGameObjectsWithTag(tileTag);
        //find the tiles that are bases
        for (int i = 0; i < allTiles.Length; i++)
        {
            bool duplicateFound = false;
            if(allTiles[i].GetComponent<TileBehavior>().value.type == TileBehavior.TileType.Base)
            {
                //if base, then check that team does not have base already assigned to it
                for(int j = 0; j < control.teams.Count; j++)
                {
                    if(allTiles[i].GetComponent<TileBehavior>().teamNum == control.teams[i].teamNum)
                    {
                        if (control.teams[i].baseTile)
                        {
                            Debug.LogWarning("Multiple bases for one team");
                            duplicateFound = true;
                            break;
                        }                        
                    }
                }
                if (duplicateFound)
                {
                    break;
                }
                //assign the base to that team
                for (int j = 0; j < control.teams.Count; j++)
                {
                    if (allTiles[i].GetComponent<TileBehavior>().teamNum == control.teams[i].teamNum)
                    {
                        control.teams[i].baseTile = allTiles[i].GetComponent<TileBehavior>();
                    }
                }
            }
        }
    }

    //finds all the other buildings and assigns to teams
    private void FindBuildings()
    {
        //get the tiles
        GameObject[] allTiles = GameObject.FindGameObjectsWithTag(tileTag);
        //find the tiles that are bases
        for (int i = 0; i < allTiles.Length; i++)
        {
            if (allTiles[i].GetComponent<TileBehavior>().value.type == TileBehavior.TileType.Building)
            {
                //assign it to the team

            }
        }
    }
}
