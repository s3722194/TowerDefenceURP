using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    private GameObject occupiedTower;
    public int x;
    public int y;
    public float nodeSize;

    public bool Occupied { get => OccupiedTower != null; }
    public GameObject OccupiedTower
    {
        get => occupiedTower;
        set
        {
            if (occupiedTower.GetComponent<ABuilding>())
            {
                occupiedTower = value;
                GetGrid().UpdatePosition(this);
            }
            else
            {
                throw new System.ArgumentException("Input must be a building!");
            }
        }
    }

    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        OccupiedTower = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(OccupiedTower == null)
        {
            if(GM.GetSelectedTower() != null)
            {
                // Place Tower
                GameObject spawnedTower = Instantiate(GM.GetSelectedTower(), this.transform.position, this.transform.rotation);
                OccupiedTower = spawnedTower;
            }
        }
    }

    public bool GetOccupied()
    {
        return OccupiedTower != null;
    }

    private MapGrid GetGrid()
    {
        return transform.parent.parent.GetComponent<MapGrid>();
    }

    /*/// <summary>
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
    }*/

  /*  /// <summary>
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
    }*/

  /*  /// <summary>
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
    }*/
}
