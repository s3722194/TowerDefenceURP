using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private float nodeSize;
    [SerializeField] private bool allowDiagonalMovement;

    private List<Vector2Int> startPositions;
    private List<Vector2Int> endPositions;
    [SerializeField] private Vector2Int offset;
    [SerializeField] private int wallThickness;

    private GridTile[,] tiles;
    [SerializeReference] private List<Path> paths;

    private int lastPathNumAssigned;

    public float EndSensitivity { get; private set; }

    // Start is called before the first frame update
    void Start()
    {

        Transform grid = transform.Find("Grid");
        int tileCount = grid.childCount;
        tiles = new GridTile[x + wallThickness * 2, y + wallThickness * 2];
        EmptyNodes();

        startPositions = new List<Vector2Int>();
        startPositions = GetStartPositions();
        endPositions = new List<Vector2Int>();
        endPositions = GetEndPositions();

        for (int i = 0; i < tileCount; i++)
        {
            Transform child = grid.GetChild(i);
            SetGridTile(child.GetComponent<GridTile>());
        }
        for (int i = 0; i < startPositions.Count; i++)
        {

        }

        paths = new List<Path>();
        bool goThroughBuildings = false;
        bool ignoreBuildings = false;

        Vector2Int startPos;
        Vector2Int endPos;

        for (int i = 0; i < startPositions.Count; i++)
        {
            for (int j = 0; j < endPositions.Count; j++)
            {
                startPos = startPositions[i];
                endPos = endPositions[j];
                Path path = CalculatePath(startPos, endPos, goThroughBuildings, ignoreBuildings);
                paths.Add(path);
            }
        }

        lastPathNumAssigned = -1;
    }

    private List<Vector2Int> GetStartPositions()
    {
        if (startPositions.Count == 0)
        {
            Transform startObject = transform.Find("Start");
            int childCount = startObject.childCount;
            List<Vector2Int> StartTiles = new List<Vector2Int>();
            for (int i = 0; i < childCount; i++)
            {
                Transform child = startObject.GetChild(i);
                Vector3 childPos = child.position;
                StartTiles.Add(new Vector2Int((int)childPos.x, (int)childPos.y));
                SetGridTile(child.GetComponent<GridTile>());
            }
            return StartTiles;
        }
        return startPositions;
    }

    private List<Vector2Int> GetEndPositions()
    {
        if (endPositions.Count == 0)
        {
            Transform endObject = transform.Find("End");
            int childCount = endObject.childCount;
            List<Vector2Int> EndTiles = new List<Vector2Int>();
            for (int i = 0; i < childCount; i++)
            {
                Transform child = endObject.GetChild(i);
                Vector3 childPos = child.position;
                EndTiles.Add(new Vector2Int((int)childPos.x, (int)childPos.y));
                SetGridTile(child.GetComponent<GridTile>());
            }
            return EndTiles;
        }
        return endPositions;
    }

    private void EmptyNodes()
    {
        for (int i = 0; i < x + wallThickness*2; i++)
        {
            for (int j = 0; j < y + wallThickness*2; j++)
            {
                tiles[i, j] = null;
            }
        }
    }

    public void UpdatePosition(GridTile tile)
    {
        Vector2Int pos = new Vector2Int((int)tile.transform.position.x, (int)tile.transform.position.y);
        SetGridTile(tile);

        bool goThroughBuildings = false;
        bool ignoreBuildings = false;

        foreach (Path path in paths)
        {
            if (path.Contains(pos))
            {
                path.UpdatePositions(AStarSearch.Search(this, path.GetStartPosition(), path.GetEndPosition(), goThroughBuildings, ignoreBuildings, allowDiagonalMovement));
            }
        }
    }
    
    public bool HasGridTile(int x, int y)
    {
        if (tiles.GetLength(0) > x && tiles.GetLength(1) > y)
        {
            return tiles[x, y] != null;
        }
        return false;
    }

    public bool HasGridTile(Vector2Int pos)
    {
        Vector2Int adjusted = new Vector2Int(pos.x - offset.x, pos.y - offset.y);
        if (adjusted.x >= tiles.GetLength(0) || adjusted.y >= tiles.GetLength(1))
        {
            return false;
        }
        return tiles[adjusted.x, adjusted.y] != null;
    }

    public GridTile GetGridTile(int i, int j)
    {
        return GetGridTile(new Vector2Int(i,j));
    }

    public GridTile GetGridTile(Vector2Int pos)
    {
        Vector2Int adjusted = new Vector2Int(pos.x - offset.x, pos.y - offset.y);
        if (adjusted.x >= tiles.Length || adjusted.y >= tiles.GetLength(1))
        {
            return null;
        }
        return tiles[adjusted.x, adjusted.y];
    }

    public void SetGridTile(GridTile gridTile)
    {
        int pos_x = (int)Math.Ceiling(gridTile.transform.position.x) - offset.x;
        int pos_y = (int)Math.Ceiling(gridTile.transform.position.y) - offset.y;
        if (pos_x >= tiles.GetLength(0) || pos_y >= tiles.GetLength(1))
        {
            throw new ArgumentOutOfRangeException("Grid tile position is too high for tilemap size");
        }
        tiles[pos_x, pos_y] = gridTile;
    }

    public int AssignPathNumber()
    {
        lastPathNumAssigned += 1;
        if (lastPathNumAssigned >= GetNumPaths())
        {
            lastPathNumAssigned = 0;
        }
        return lastPathNumAssigned;
    }

    public void ResetPathNumber()
    {
        lastPathNumAssigned = -1;
    }

    public int GetNumPaths()
    {
        return paths.Count;
    }

    public Path GetPath(int pathNum)
    {
        if (pathNum >= GetNumPaths() || pathNum < 0)
        {
            throw new ArgumentOutOfRangeException("Path number must between 0 and " + GetNumPaths().ToString() + " inclusive");
        }
        else
        {
            return paths[pathNum];
        }
    }

    private Path CalculatePath(Vector2Int startPos, Vector2Int endPos, bool goThroughBuildings, bool ignoreBuildings)
    {
        return new Path(AStarSearch.Search(this, startPos, endPos, goThroughBuildings, ignoreBuildings, allowDiagonalMovement));
    }
}
