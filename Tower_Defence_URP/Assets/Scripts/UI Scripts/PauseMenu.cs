using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;

    void Start()
    {
        if(PauseCanvas != null && PauseCanvas.activeSelf)
        {
            PauseCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseCanvas.activeSelf)
            {
                PauseGame();
            } else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ToMainMenu()
    {

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
