using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLocation : MonoBehaviour
{
    public GameObject buildingPrefab;
    private GameObject building;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CanPlaceBuilding()
    {
        return building == null;
    }

    private bool CanUpgradeBuilding()
    {
        if (building != null)
        {

        }
        return false;
    }
}
