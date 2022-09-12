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

    private GridTile[,] tiles;
    private List<Path> paths;

    private int lastPathNumAssigned;

    // Start is called before the first frame update
    void Start()
    {
        startPositions = GetStartPositions();
        endPositions = GetEndPositions();

        Transform grid = transform.Find("Grid");
        int tileCount = grid.childCount;

        EmptyNodes();
        Vector3 position;
        for (int i = 0; i < tileCount; i++)
        {
            Transform child = grid.GetChild(i);
            position = child.position;
            tiles[(int)position.x, (int)position.y] = child.GetComponent<GridTile>();
        }

        paths = new List<Path>();
        bool goThroughBuildings = false;
        bool ignoreBuildings = false;

        for (int i = 0; i < startPositions.Count; i++)
        {
            for (int j = 0; j < endPositions.Count; j++)
            {
                paths.Add(CalculatePath(startPositions[i], endPositions[i], goThroughBuildings, ignoreBuildings));
            }
        }

        lastPathNumAssigned = -1;
    }

    private List<Vector2Int> GetStartPositions()
    {
        if (startPositions.Count > 0)
        {
            return startPositions;
        }
        Transform startObject = transform.Find("Start");
        int childCount = startObject.childCount;
        List<Vector2Int> StartTiles = new List<Vector2Int>();
        for (int i = 0; i < childCount; i++)
        {
            Vector3 childPos = startObject.GetChild(i).position;
            StartTiles.Add(new Vector2Int((int)childPos.x, (int)childPos.y));
        }
        return StartTiles;
    }

    private List<Vector2Int> GetEndPositions()
    {
        if (endPositions.Count > 0)
        {
            return endPositions;
        }
        Transform endObject = transform.Find("End");
        int childCount = endObject.childCount;
        List<Vector2Int> EndTiles = new List<Vector2Int>();
        for (int i = 0; i < childCount; i++)
        {
            Vector3 childPos = endObject.GetChild(i).position;
            EndTiles.Add(new Vector2Int((int)childPos.x, (int)childPos.y));
        }
        return EndTiles;
    }

    private void EmptyNodes()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                tiles[i, j] = null;
            }
        }
    }

    public void UpdatePosition(GridTile tile)
    {
        Vector2Int pos = new Vector2Int((int)tile.transform.position.x, (int)tile.transform.position.y);
        tiles[pos.x, pos.y] = tile;

        bool goThroughBuildings = false;
        bool ignoreBuildings = false;

        foreach (Path path in paths)
        {
            if (path.Contains(pos))
            {
                AStarSearch.Search(this, path[0], path[-1], goThroughBuildings, ignoreBuildings, allowDiagonalMovement);
            }
        }
    }

    public bool HasGridTile(int i, int j)
    {
        return HasGridTile(new Vector2Int(i,j));
    }

    public bool HasGridTile(Vector2Int pos)
    {
        return tiles[pos.x, pos.y] != null;
    }

    public GridTile GetGridTile(int i, int j)
    {
        return GetGridTile(new Vector2Int(i,j));
    }

    public GridTile GetGridTile(Vector2Int pos)
    {
        return tiles[pos.x, pos.y];
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

    public Path GetPathFromNumber(int pathNum)
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

    public List<Vector2Int> GetPath(int entryNum = 0, int exitNum = 0)
    {
        if (entryNum >= startPositions.Count)
        {
            throw new ArgumentOutOfRangeException("entryNum must be smaller than the number of entrances");
        }
        if (exitNum >= endPositions.Count)
        {
            throw new ArgumentOutOfRangeException("exitNum must be smaller than the number of exits");
        }
        return GetPath(startPositions[entryNum], endPositions[exitNum]);
    }

    public List<Vector2Int> GetPath(Vector2Int startPos, int exitNum = 0)
    {
        if (exitNum >= endPositions.Count)
        {
            throw new ArgumentOutOfRangeException("exitNum must be smaller than the number of exits");
        }
        return GetPath(startPos, endPositions[exitNum]);
    }

    /// <summary>
    /// A* pathfinding between two points. Gets cost from Node.WalkCost().
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <returns></returns>
    public List<Vector2Int> GetPath(Vector2Int startPos, Vector2Int endPos)
    {
        throw new NotImplementedException();
    }

    private Path CalculatePath(Vector2Int startPos, Vector2Int endPos, bool goThroughBuildings, bool ignoreBuildings)
    {
        return new Path(AStarSearch.Search(this, startPos, endPos, goThroughBuildings, ignoreBuildings, allowDiagonalMovement));
    }
}
