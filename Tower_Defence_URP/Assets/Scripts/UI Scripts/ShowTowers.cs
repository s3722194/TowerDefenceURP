using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTowers : MonoBehaviour
{
    public GameObject TowerPanel;

    public void ToggleTowerPanel()
    {
        if(!TowerPanel.activeSelf)
        {
            TowerPanel.SetActive(true);
        } else
        {
            TowerPanel.SetActive(false);
        }
    }
}
