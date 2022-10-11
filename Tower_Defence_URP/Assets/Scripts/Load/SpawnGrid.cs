using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject gridPrefab;
    [SerializeField]
    private GameObject startPrefab;
    [SerializeField]
    private GameObject endPrefab;
    [SerializeField]
    private GameObject wallPrefab;
    [SerializeField]
    [Range(4f, 20f)]
    private int height;
    [SerializeField]
    [Range(4f, 20f)]
    private int width;
    [SerializeField]
    private bool randomStart = true;

    //might need to make a list later
    [SerializeField]
    private Vector2 opening;
    [SerializeField]
    private Vector2 end;
    [SerializeField] [Range(0,1)]
    private float endSensitivity;

    [SerializeField]
    private GameObject gridParent;
    [SerializeField]
    private GameObject wallParent;
    [SerializeField]
    private GameObject startParent;
    [SerializeField]
    private GameObject endParent;

    public Vector2 Opening { get => opening; private set => opening = value; }
    public Vector2 End { get => end; private set => end = value; }
    public float EndSensitivity { get => endSensitivity; private set => endSensitivity = value; }

    // Start is called before the first frame update
    void Start() { 
       // height = grid.\
        DisplayGrid();

        DisplayWalls();

    }

    private void DisplayWalls()
    {
        if (randomStart)
        {
            //current  randomly chose a start and end on the north and south wallls
            //just for testing. can change later
            Opening = new Vector2(Random.Range(-width / 2, width/2), (height/2));
            end = new Vector2(Random.Range(-width / 2, width/2), (-height/2) -1);

        }

        GameObject startTile = Instantiate(startPrefab, Opening, Quaternion.identity);
        startTile.transform.parent = startParent.transform;

        GameObject endTile = Instantiate(endPrefab, end, Quaternion.identity);
        endTile.transform.parent = startParent.transform;

        print("Start: " + Opening);
        print("End: " + end);

        for (int i = (-height / 2)-1; i <= height / 2; i++)
        {
            Vector2 northPosition = new Vector2((width / 2), i);
            Vector2 southPosition = new Vector2((-width / 2) - 1, i);

            if (northPosition != Opening && northPosition != end)
            {
                GameObject northTile = Instantiate(wallPrefab, northPosition, Quaternion.identity);
                northTile.transform.parent = wallParent.transform;
                northTile.name = "WallTile (" + northPosition.x + ", " + northPosition.y + ")";
            }

            if (southPosition != Opening && southPosition != end)
            {
                GameObject southTile = Instantiate(wallPrefab, southPosition, Quaternion.identity);
                southTile.transform.parent = wallParent.transform;
                southTile.name = "WallTile (" + southPosition.x + ", " + southPosition.y + ")";
            }
                

        }

        for (int i = (-width / 2)-1; i <= width / 2; i++)
        {
            Vector2 eastPosition = new Vector2(i, (height / 2) );
            Vector2 westPosition = new Vector2(i, (-height / 2) - 1);
            if (eastPosition != Opening && eastPosition != end)
            {
                GameObject eastTile = Instantiate(wallPrefab, eastPosition, Quaternion.identity);
                eastTile.transform.parent = wallParent.transform;
                eastTile.name = "WallTile (" + eastPosition.x + ", " + eastPosition.y + ")";
            }

            if (westPosition != Opening && westPosition != end)
            {
                GameObject westTile = Instantiate(wallPrefab, westPosition, Quaternion.identity);
                westTile.transform.parent = wallParent.transform;
                westTile.name = "WallTile (" + westPosition.x + ", " + westPosition.y + ")";
            }

            
        }
        
    }

    private void DisplayGrid()
    {
        int y = 0;
        int x = 0;
        for (int i = -height / 2; i < height / 2; i++)
        {
            
            for (int j = -width / 2; j < width / 2; j++)
            {
                
                GameObject tile = Instantiate(gridPrefab, new Vector3(i, j, 0), Quaternion.identity);
                tile.name = "GridTile (" + i + ", " + j + ")";
                tile.transform.parent = gridParent.transform;
                GridTile gridTile = tile.GetComponent<GridTile>();
                gridTile.x = x;
                gridTile.y = y;
                gridTile.nodeSize = 1;
                y++;
            }
            x++;
            y = 0;
        }
    }
}
