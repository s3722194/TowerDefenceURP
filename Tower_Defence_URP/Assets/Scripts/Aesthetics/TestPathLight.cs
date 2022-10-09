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
        for(int i = 0; i < length; i++)
        {
            GameObject newLight = Instantiate(pathLight);
           
            newLight.transform.position = new Vector3(newLight.transform.position.x, i, newLight.transform.position.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
