using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntialiseRandom : MonoBehaviour
{
    void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
}
