using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button button;
 
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Grid Handdrawn", LoadSceneMode.Single);
    }


}
