using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject selectedTower;

    [SerializeField] private int lives;
    [SerializeField] private int money;
    private AudioManager audioManager;

    public int Money {  get => money; set => money =value; }
    public int Lives { get => lives; set => lives = value; }
    public int MaxLives { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // probs want to initialise these values
        // idk what they are so i wont touch them
        selectedTower = null;
        MaxLives = lives;
        Time.timeScale = 1.0f;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        Application.runInBackground = true;
    }

    public void Escape(EnemyUnit unit)
    {
        Lives -= unit.LivesOnEscape;
        unit.Escape();
        if (Lives <= 0)
        {
            audioManager.PlaySound(AudioManager.Sound.GameOver);
            SceneManager.LoadScene("GameOver");
            StartCoroutine(UnLoadGrid());
        }
    }

    IEnumerator UnLoadGrid()
    {

        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync("Grid HandDrawn");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void SpendMoney(int cost)
    {
        Money -= cost;
    }

    public void SetSelectedTower(GameObject _selectedTower)
    {
        selectedTower = _selectedTower;
    }

    public void ResetTower()
    {
        selectedTower = null;
    }

    public GameObject GetSelectedTower()
    {
        return selectedTower;
    }
}
