using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCosts : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private Button button;
    
    private GameManager gm;
    private ABuilding building;
    private UpgradeHUD upgrade;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
        upgrade = GameObject.Find("Upgrade_HUD").GetComponent<UpgradeHUD>();

        if (towerPrefab != null)
        {
            building = towerPrefab.GetComponent<ABuilding>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("Upgrade"))
        {
            if(upgrade.selectedTower != null)
            {
                building = upgrade.selectedTower.GetComponent<ABuilding>();
            }

            if (building.UpgradeCost > gm.Money)
            {
                button.interactable = false;
            } else
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
            }
        } else
        {
            if(building.Cost > gm.Money)
            {
                button.interactable = false;
                GameObject infoPanel = GameObject.FindGameObjectWithTag("InfoPanel");
                if (infoPanel != null && infoPanel.activeSelf)
                {
                    infoPanel.SetActive(false);
                    gm.ResetTower();
                }
            } else
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
            }
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
            playButton.interactable = false;

            GameObject infoPanel = GameObject.FindGameObjectWithTag("InfoPanel");
            if(infoPanel != null && infoPanel.activeSelf)
            {
                infoPanel.SetActive(false);
                gm.ResetTower();
            }
        } else
        {
            Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
            playButton.interactable = true;
        }
    }
}
