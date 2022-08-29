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
        float x = -SouthWestCorner.x;
        float y = -SouthWestCorner.y;

        grid = GameObject.FindGameObjectWithTag("Grid");

        foreach( Transform child in grid.transform)
        {
            GridTile tile = child.GetComponent<GridTile>();
            if(tile != null)
            {
                tile.x = (int)(tile.x - x);
                tile.y = (int)(tile.y - y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
