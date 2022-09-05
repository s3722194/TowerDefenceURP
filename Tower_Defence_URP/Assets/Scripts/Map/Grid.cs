using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private float nodeSize;

    private List<Vector2Int> startPositions;
    private List<Vector2Int> endPositions;

    private bool[,] nodes;
    private List<Vector2Int>[] paths;

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
            position = grid.GetChild(i).position;
            nodes[(int)position.x, (int)position.y] = true;
        }

        paths = new List<Vector2Int>[startPositions.Count * endPositions.Count];
        for (int i = 0; i < startPositions.Count; i++)
        {
            for (int j = 0; j < endPositions.Count; j++)
            {
                paths[i * endPositions.Count + j] = GetPath(i, j);
            }
        }
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
                nodes[i, j] = false;
            }
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
        List<Vector2Int> path = new List<Vector2Int>();

        List<Vector2Int> visited = new List<Vector2Int>();
        List<Vector2Int> frontier = new List<Vector2Int>();
        throw new NotImplementedException();
        return path;
    }
}
