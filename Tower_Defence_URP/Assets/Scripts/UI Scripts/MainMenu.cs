using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;

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
