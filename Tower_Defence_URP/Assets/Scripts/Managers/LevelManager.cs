using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject gridBackground;
    [SerializeField] private GameObject map;

    [SerializeField] private List<Material> wallMaterials = new List<Material>();
    [SerializeField] private List<Material> tileMaterials = new List<Material>();
    [SerializeField] private List<Material> startMaterials = new List<Material>();
    [SerializeField] private List<Material> endMaterials = new List<Material>();

    private List<Tuple<EnemyUnit, float>> spawnQueue = new List<Tuple<EnemyUnit, float>>();

    [SerializeField] private float waveStartDelay;
    [SerializeField] private List<Wave> waves;

    //to calculate the x and y coordinates for the game

    private Dictionary<string, Vector2> southWestCorners = new Dictionary<string, Vector2>();

    private float time;
    private int waveNum;
    private int prevWave;
    private bool autoNextWave;
    private const float waitTime = 1.5f;
    private float timeElapsed;
    private TextMeshProUGUI wavesCompleted;

    public Dictionary<string, Vector2> SouthWestCorners { get => southWestCorners; }
    public GameObject Background { get => background; set => background = value; }
    public GameObject GridBackground { get => gridBackground; set => gridBackground = value; }
    public GameObject Map { get => map; set => map = value; }

    public List<Material> TileMaterials { get => tileMaterials; }
    public List<Material> StartMaterials { get => startMaterials; }
    public List<Material> EndMaterials { get => endMaterials; }
    public List<Material> WallMaterials { get => wallMaterials; }
    public bool WaveInProgress { get; private set; }

    private GameManager gameManager;
    private AudioManager audioManager;

    private void Awake()
    {
        southWestCorners.Add("Map_9x9", new Vector2(-4, -4));
        southWestCorners.Add("Map_19x19", new Vector2(-9, -9));
        southWestCorners.Add("Map_17x17", new Vector2(-8, -8));
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        waveNum = 0;
        prevWave = 0;
        timeElapsed = 0.0f;
        WaveInProgress = false;
        wavesCompleted = GameObject.Find("WavesFinished").GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        // audioManager.PlaySound(AudioManager.Sound.GameStart);
        audioManager.PlayMusic(AudioManager.Music.BuildingPhase);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnQueue.Count > 0 && gameManager.Lives > 0)
        {
            WaveInProgress = true;
            time += Time.deltaTime;
            if (time > spawnQueue[0].Item2)
            {
                Instantiate(spawnQueue[0].Item1);
                spawnQueue.RemoveAt(0);
                time = 0f;
            }
        }
        if (prevWave < waveNum)
        {
            WaveInProgress = true;
            if(timeElapsed >= waitTime)
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
                {
                    wavesCompleted.text = waveNum.ToString();
                    gameManager.Money += waves[prevWave].EndWaveBonus;
                    prevWave = waveNum;
                    timeElapsed = 0.0f;
                    WaveInProgress = false;
                    if (autoNextWave)
                    {
                        SendWave();
                    }
                }
            }
            else
            {
                timeElapsed += Time.deltaTime;
            }
        }
    }

    public void SendWave()
    {
        audioManager.PlaySound(AudioManager.Sound.WaveStart);
        audioManager.PlayMusic(AudioManager.Music.AttackPhase);

        if (waveNum >= waves.Count)
        {
            Wave wave = waves[waves.Count - 1];
            int extraWaveCount = waveNum - waves.Count + 1;

            for (int i = 0; i < wave.Length; i++)
            {
                Wave.Spawn spawn = wave.SpawnList[i];
                for (int j = 0; j < extraWaveCount; j++)
                {
                    float delay = i+j == 0 ? waveStartDelay : spawn.delayToThis / extraWaveCount;
                    Tuple<EnemyUnit, float> spawnItem = new Tuple<EnemyUnit, float>(spawn.enemy, delay);
                    spawnQueue.Add(spawnItem);
                }
            }
        }
        else
        {
            Wave wave = waves[waveNum];

            for (int i = 0; i < wave.Length; i++)
            {
                Wave.Spawn spawn = wave.SpawnList[i];
                float delay = i == 0 ? waveStartDelay : spawn.delayToThis;
                Tuple<EnemyUnit, float> spawnItem = new Tuple<EnemyUnit, float>(spawn.enemy, delay);
                spawnQueue.Add(spawnItem);
            }
        }
        waveNum += 1;
    }

    public int GetWave()
    {
        return waveNum;
    }

    public void ToggleAutoSendWaves()
    {
        autoNextWave = !autoNextWave;
    }

    public void SetAutoSendWaves(bool autoSend)
    {
        autoNextWave = autoSend;
    }
}
