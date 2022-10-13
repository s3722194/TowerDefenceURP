using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCosts : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private Button button;

    private GameManager gameManager;
    private LevelManager levelManager;
    private ABuilding building;
    private UpgradeHUD upgrade;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

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

            if (building.UpgradeCost > gameManager.Money)
            {
                button.interactable = false;
            }
            else
            {
                if (levelManager.WaveInProgress)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
            }
        }
        else
        {
            if(building.Cost > gameManager.Money)
            {
                button.interactable = false;
                GameObject infoPanel = checkInfoPanel();
                if (infoPanel != null && infoPanel.activeSelf)
                {
                    infoPanel.SetActive(false);
                    gameManager.ResetTower();
                }
            }
            else
            {
                if (levelManager.WaveInProgress)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
            }
        }

        if (levelManager.WaveInProgress)
        {
            Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
            playButton.interactable = false;

            GameObject infoPanel = GameObject.FindGameObjectWithTag("InfoPanel");
            if(infoPanel != null && infoPanel.activeSelf)
            {
                infoPanel.SetActive(false);
                gameManager.ResetTower();
            }
        }
        else
        {
            Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
            playButton.interactable = true;
        }
    }

    private GameObject checkInfoPanel()
    {
        GameObject[] infoPanels = GameObject.FindGameObjectsWithTag("InfoPanel");
        
        foreach(GameObject panel in infoPanels)
        {
            InfoTag tag = panel.GetComponent<InfoTag>();

            if(tag != null && tag.InfoPanelTag.Equals(building.tag))
            {
                Debug.Log("found");
                return panel;
            }
        }

        return null;
    }
}
