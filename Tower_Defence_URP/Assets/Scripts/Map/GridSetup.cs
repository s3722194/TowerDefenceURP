using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetup : MonoBehaviour
{
    [SerializeField]
    private Vector2 SouthWestCorner;
    [SerializeField]
    private Vector2 NorthEastCorner;
    private GameObject grid;
    // Start is called before the first frame update
    void Start()
    {
        float x = SouthWestCorner.x;
        float y = SouthWestCorner.y;

        grid = GameObject.FindGameObjectWithTag("Grid");

        foreach( Transform child in grid.transform)
        {
            
            GridTile tile = child.GetComponent<GridTile>();
            if(tile != null)
            {
                print(child.name);
               
                float newX = child.transform.position.x - x;
                float newY = child.transform.position.y - y;

                // in tranform sometimes numbers get store as 0.999999 even tho its practically 1
                // so i need to ceil it
                tile.x = (int) Mathf.Ceil(newX);
                tile.y = (int) Mathf.Ceil(newY);
                tile.nodeSize = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
