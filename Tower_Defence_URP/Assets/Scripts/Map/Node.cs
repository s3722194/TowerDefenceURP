using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private int x;
    private int y;
    private float nodeSize;
    private ABuilding building;

    public ABuilding Building { get => building; set => building = value; }
    public bool Occupied { get => Building != null; }

    public Node(int x, int y, float nodeSize)
    {
        this.x = x;
        this.y = y;
        this.nodeSize = nodeSize;
        this.Building = null;
    }

    public bool GetOccupied()
    {
        return Building != null;
    }

    /*
    /// <summary>
    /// Checks if a tower can be placed on this node.
    /// </summary>
    /// <returns></returns>
    public bool CanPlace(Grid grid)
    {
        if (!grid.ContainsNode(this))
        {
            throw new System.InvalidOperationException("Node.CanPlace() must be given a valid grid containing the node");
        }
        return Occupied;
    }

    /// <summary>
    /// Checks if enemies are able to travel through this space.
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public bool CanWalk(Grid grid)
    {
        if (!grid.ContainsNode(this))
        {
            throw new System.InvalidOperationException("Node.CanPlace() must be given a valid grid containing the node");
        }
        return Occupied;
    }

    /// <summary>
    /// Checks if enemies are able to travel through this space.
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="damage"></param>
    /// <returns></returns>
    public float WalkCost(Grid grid, int damage)
    {
        if (!grid.ContainsNode(this))
        {
            throw new System.InvalidOperationException("Node.CanPlace() must be given a valid grid containing the node");
        }
        if (Occupied)
        {
            if (damage <= 0)
            {
                return -1;
            }
            else
            {
                return Building.Health / damage;
            }
        }
        else
        {
            return 0;
        }
    }
    */

}
