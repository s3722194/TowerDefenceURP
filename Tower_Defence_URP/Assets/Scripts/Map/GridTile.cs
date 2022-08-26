using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public int x;
    public int y;
    public float nodeSize;
    private ABuilding building;
    private SpriteRenderer spriteRenderer;

    private bool mouseDrag = false;

    public ABuilding Building { get => building; set => building = value; }
    public bool Occupied { get => Building != null; }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDrag()
    {
        print("Mouse Drag");
       mouseDrag = true;
      //  spriteRenderer.color = new Color(29.0f / 255.0f, 27.0f / 255.0f, 27.0f / 255.0f, 1.0f);
    }

    public void OnMouseDown()
    {
        spriteRenderer.color = new Color(188.0f / 255.0f, 198.0f / 255.0f, 214.0f / 255.0f);
    }

    public void OnMouseUp()
    {
        print("Click! "+x+" ,"+y);
        //spriteRenderer.color = new Color(99.0f / 255.0f, 106.0f / 255.0f, 117.0f / 255.0f, 1.0f);
        mouseDrag = false;
    }

    public void OnMouseEnter()
    {
        //print("Tile: " + x + " ," + y +" "+ "Mouse Enter");
        spriteRenderer.color = new Color(99.0f/255.0f, 106.0f / 255.0f, 117.0f / 255.0f, 1.0f);
       // spriteRenderer.color = Color.red;
    }

    public void OnMouseExit()
    {
        //print("Tile: " + x + " ," + y + " " + "Mouse Exit");
        spriteRenderer.color = new Color(29.0f / 255.0f, 27.0f / 255.0f, 27.0f / 255.0f, 1.0f);
       // spriteRenderer.color = Color.black;
    }




    public bool GetOccupied()
    {
        return Building != null;
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
