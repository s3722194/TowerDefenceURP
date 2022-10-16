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
    private AudioManager AM;
    private UpgradeHUD upgradeCanvas;
    private MapGrid mapGrid;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        AM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
                Building building = selectedTower.GetComponent<Building>();
                

                if(building != null && GM.Money >= building.Cost)
                {
                    // Place Tower
                    GameObject spawnedTower = Instantiate(GM.GetSelectedTower(), transform.position, transform.rotation);
                    OccupiedTower = spawnedTower;
                    towerRange = spawnedTower.GetComponent<ShowRange>().GetRange();
                   
                    GM.SpendMoney(building.Cost);
                    mapGrid.UpdatePosition(this);
                    AM.PlaySound(AudioManager.Sound.PlaceTower);
                } 
            }
        }
        else
        {
            upgradeCanvas.UpdateHUD(occupiedTower, towerRange);
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
}
