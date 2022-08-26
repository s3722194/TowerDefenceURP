using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private float nodeSize;

    [SerializeField] private List<Vector2Int> startPositions;
    [SerializeField] private List<Vector2Int> endPositions;
    [SerializeField] private List<Vector2Int> exceptions;

    private List<Node> nodes;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; i < y; i++)
            {
                if (exceptions.Contains(new Vector2Int(i, j)))
                {
                    continue;
                }
                else
                {
                    Node node = new Node(i, j, nodeSize);
                    nodes.Add(node);
                }
            }
        }
    }

    internal bool ContainsNode(Node node)
    {
        return nodes.Contains(node);
    }

    public List<Node> GetPath(int entryNum = 0, int exitNum = 0)
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

    public List<Node> GetPath(Vector2Int startPos, int exitNum = 0)
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
    public List<Node> GetPath(Vector2Int startPos, Vector2Int endPos)
    {
        List<Node> path = new List<Node>();

        List<Node> visited = new List<Node>();
        List<Node> active = new List<Node>();
        throw new NotImplementedException();
        return path;
    }
}
