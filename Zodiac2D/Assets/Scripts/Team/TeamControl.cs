using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamControl : MonoBehaviour
{
    public int teamNum = 0; //the team number for this team

    [Header("My tiles")]
    public TileBehavior baseTile;
    public List<TileBehavior> myBuildings = new List<TileBehavior>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
