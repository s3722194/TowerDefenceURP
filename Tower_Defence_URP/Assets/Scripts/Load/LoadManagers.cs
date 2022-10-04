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
}
