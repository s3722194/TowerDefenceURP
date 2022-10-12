using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveReached : MonoBehaviour
{
    [SerializeField]private TMP_Text text; 
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
       LevelManager levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
       int waves = levelManager.getWave();
        text.text = "Wave Reached: " + waves;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
