using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLighting : MonoBehaviour
{

    [SerializeField] private bool isLit = false;
    [SerializeField] private GameObject lit;
    [SerializeField] private GameObject unlit;
    // Start is called before the first frame update
    void Start()
    {
        if (isLit)
        {
            lit.SetActive(true);
            unlit.SetActive(false);
        }
        else
        {
            lit.SetActive(false);
            unlit.SetActive(true);
        }
    }

    // Update is called once per frame
 
}
