using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public int x;
    public int y;
    public float nodeSize;
    private GameObject towerRange;

    public bool Occupied { get => OccupiedTower != null; }
    public GameObject OccupiedTower { get; set; }

    private GameManager gameManager;
    private AudioManager audioManager;
    private UpgradeHUD upgradeCanvas;
    private MapGrid mapGrid;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
            if(gameManager.GetSelectedTower() != null)
            {
                GameObject selectedTower = gameManager.GetSelectedTower();
                Building building = selectedTower.GetComponent<Building>();
                
                if(CanPlaceTower(building))
                {
                    // Place Tower
                    GameObject spawnedTower = Instantiate(gameManager.GetSelectedTower(), transform.position, transform.rotation);
                    OccupiedTower = spawnedTower;
                    towerRange = spawnedTower.GetComponent<ShowRange>().GetRange();
                   
                    gameManager.SpendMoney(building.Cost);
                    mapGrid.UpdatePosition(this);
                    audioManager.PlaySound(AudioManager.Sound.PlaceTower);
                } 
            }
        }
        else
        {
            upgradeCanvas.UpdateHUD(OccupiedTower, towerRange);
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
            gameManager.ResetTower();
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


    public bool CanPlaceTower(Building building)
    {
        bool canPlace = true;
        canPlace = canPlace && building != null;
        canPlace = canPlace && gameManager.Money >= building.Cost;
        // Expensive, run last
        canPlace = canPlace && mapGrid.CanPlaceBuilding(this);
        return canPlace;
    }

    public bool GetOccupied()
    {
        return OccupiedTower != null;
    }
}
