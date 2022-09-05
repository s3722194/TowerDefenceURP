using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtons : MonoBehaviour
{
    public GameObject TowerPanel;
    public GameManager gm;

    [SerializeField] private GameObject TowerPrefab;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void ToggleTowerPanel()
    {
        if (!TowerPanel.activeSelf)
        {
            TowerPanel.SetActive(true);
        }
        else
        {
            TowerPanel.SetActive(false);
        }
    }

    public void SelectTower()
    {
        gm.setSelectedTower(TowerPrefab);
    }
}
