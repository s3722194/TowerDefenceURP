using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField] private GameObject HelpMenuCanvas;
    [SerializeField] private GameObject MainMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        audioManager.PlayMusic(AudioManager.Music.Menu);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Grid HandDrawn");
    }

    public void ToHelp()
    {
        HelpMenuCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);

        HelpMenu help = GameObject.FindObjectOfType<HelpMenu>();
        if(help != null)
        {
            help.RestartPasses();
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
