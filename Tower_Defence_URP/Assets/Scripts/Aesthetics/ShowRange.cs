using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRange : MonoBehaviour
{
    [SerializeField] private GameObject rangeObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        // Building building = transform.parent.GetComponent<Building>();
        // rangeObject.transform.localScale = new Vector3(building.Range * 2, building.Range * 2, 1);
    }

    public GameObject GetRange()
    {
        return rangeObject;
    }
}
