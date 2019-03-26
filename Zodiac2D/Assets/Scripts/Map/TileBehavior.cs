using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    [System.Serializable]
    public struct TileValues
    {
        //public string name;
        public TileType type;
        public int coverVal;
    }

    [System.Serializable]
    public struct TilePosition
    {
        public int xPos;
        public int yPos;
    }

    [System.Serializable]
    public struct TileNeighbours
    {
        public TileBehavior xPosTile; //where other is to +ve x
        public TileBehavior yPosTile; //where other is to +ve z
        public TileBehavior xNegTile; //where other is to -ve x
        public TileBehavior yNegTile; //where other is to -ve z
    }

    public enum TileType
    {
        Plains,
        Road,
        Building,
        Base,
        River,
        Sea
    }

    public TileValues value;
    public TilePosition position;
    public TileNeighbours neighbours;

    //[Header("Tile details")]
    //public int coverVal = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //remove self from list
    public void RemoveSelf()
    {
        if (transform.GetComponentInParent<MapHandler>())
        {
            transform.GetComponentInParent<MapHandler>().RemoveTile(this);
        }
    }

    //on destroy, tell its map to remove self from list
    private void OnDestroy()
    {
        if (transform.GetComponentInParent<MapHandler>())
        {
            transform.GetComponentInParent<MapHandler>().RemoveTile(this);
        }
    }

    //compares the two tiles, and returns true if the same
    public bool CheckIfSame(TileBehavior other)
    {
        bool same = false;
        if (position.xPos == other.position.xPos
            && position.yPos == other.position.yPos
            /*&& properties.type == other.properties.type*/)
        {
            same = true;
        }

        return same;
    }

    //Copy information from one tile to another
    public void CopyTileInfo(TileBehavior other)
    {
        //copy information
        position.xPos = other.position.xPos;
        position.yPos = other.position.yPos;
        //information.height = other.information.height;

        //copy properties
        value.type = other.value.type;
    }

    //get the tile type
    public TileType GetTileType()
    {
        return value.type;
    }

    //get coords
    public Vector3 GetWorldCoord()
    {
        Vector3 inWorldPos = new Vector3(position.xPos, position.yPos, 0.0f);
        return inWorldPos;
    }

    public int GetXCoord()
    {
        return position.xPos;
    }

    public int GetYCoord()
    {
        return position.yPos;
    }
}
