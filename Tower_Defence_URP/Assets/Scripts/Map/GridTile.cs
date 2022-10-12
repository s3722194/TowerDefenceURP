using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    private GameObject occupiedTower;
    public int x;
    public int y;
    public float nodeSize;
    private GameObject towerRange;

    public bool Occupied { get => OccupiedTower != null; }
    public GameObject OccupiedTower
    {
        get => occupiedTower;
        set
        {
            occupiedTower = value;
        }
    }

    private GameManager GM;
    private UpgradeHUD upgradeCanvas;
    private MapGrid mapGrid;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        upgradeCanvas = GameObject.Find("Upgrade_HUD").GetComponent<UpgradeHUD>();
        mapGrid = transform.parent.parent.gameObject.GetComponent<MapGrid>();

        OccupiedTower = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(!OccupiedTower)
        {
            OccupiedTower = null;
        }
    }

    void OnMouseDown()
    {
        if(OccupiedTower == null)
        {
            if(GM.GetSelectedTower() != null)
            {
                GameObject selectedTower = GM.GetSelectedTower();
                ABuilding building = selectedTower.GetComponent<ABuilding>();
                

                if(building != null && GM.Money >= building.Cost)
                {
                    // Place Tower
                    GameObject spawnedTower = Instantiate(GM.GetSelectedTower(), transform.position, transform.rotation);
                    OccupiedTower = spawnedTower;
                    towerRange = spawnedTower.GetComponent<ShowRange>().getRange();
                   
                    GM.SpendMoney(building.Cost);
                    mapGrid.UpdatePosition(this);
                } 
            }
        } else
        {
            upgradeCanvas.updateHUD(occupiedTower, towerRange);
            towerRange.SetActive(true);
            GameObject info_canvas = GameObject.Find("Info_Canvas");
            foreach (Transform panel in info_canvas.GetComponentsInChildren<Transform>())
            {
                if (panel.gameObject.name != "Info_Canvas")
                {
                    if (panel.gameObject.activeSelf)
                    {
                        panel.gameObject.SetActive(false);
                        towerRange.SetActive(false);
                       
                    }
                }
            }

            GM.ResetTower();
        }
    }

    private void OnMouseExit()
    {
        if(towerRange != null)
        {
            towerRange.SetActive(false);

        }
            
    }

    private void OnMouseEnter()
    {
        if (towerRange != null)
        {
            towerRange.SetActive(true);
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
