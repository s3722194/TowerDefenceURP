using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPathLight : MonoBehaviour
{
    public GameObject pathLight;
    public int length;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newLight;
        for (int i = 0; i < length; i++)
        {
            newLight = Instantiate(pathLight);

            newLight.transform.position = new Vector3(newLight.transform.position.x, i, newLight.transform.position.z);
        }

      //  GameObject newLight = Instantiate(pathLight);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
