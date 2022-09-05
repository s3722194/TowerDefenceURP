using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGrid : MonoBehaviour
{

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        SetUpScene();
    }

    private void SetUpScene()
    {
        Instantiate(levelManager.Background);
        Instantiate(levelManager.GridBackground);
        Instantiate(levelManager.Map);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
