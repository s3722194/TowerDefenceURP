using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseRandom : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
