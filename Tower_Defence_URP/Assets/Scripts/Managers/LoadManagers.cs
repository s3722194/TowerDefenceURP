using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManagers : MonoBehaviour
{

    private void Awake()
    {
        string managerLevel = "Managers";
        if (!SceneManager.GetSceneByName(managerLevel).isLoaded)
        {
            SceneManager.LoadScene(managerLevel, LoadSceneMode.Additive);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
