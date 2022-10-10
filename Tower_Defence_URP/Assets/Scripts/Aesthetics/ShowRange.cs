using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRange : MonoBehaviour
{

    [SerializeField] private GameObject rangeObject;
    [SerializeField] private float rangeScale;
    // Start is called before the first frame update
    void Start()
    {
        rangeObject.SetActive(false);
        rangeObject.transform.localScale = new Vector3 (rangeScale, rangeScale, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        print("click toxic tower");
        rangeObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        rangeObject.SetActive(false);
    }
}
