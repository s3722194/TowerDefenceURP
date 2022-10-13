using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject background;
    [SerializeField]
    private GameObject gridBackground;
    [SerializeField]
    private GameObject map;

    [SerializeField]
    private List<Material> wallMaterials = new List<Material>();
    [SerializeField]
    private List<Material> tileMaterials = new List<Material>();
    [SerializeField]
    private List<Material> startMaterials = new List<Material>();
    [SerializeField]
    private List<Material> endMaterials = new List<Material>();

    [SerializeField]
    private List<EnemyUnit> enemies = new List<EnemyUnit>();
    private List<Tuple<EnemyUnit, float>> spawnQueue = new List<Tuple<EnemyUnit, float>>();
    [SerializeField]
    private float enemySpawnDelay;
    

    //to calcualte the x and y corrdinates for the game
    
    private Dictionary<string, Vector2> southWestCorners = new Dictionary<string, Vector2>();

    private float time;
    private GameObject ui;
    //private GameObject managers;
    private int waveNum;
    private TextMeshProUGUI wavesCompleted;

    public Dictionary<string, Vector2> SouthWestCorners { get => southWestCorners; }
    public GameObject Background { get => background; set => background = value; }
    public GameObject GridBackground { get => gridBackground; set => gridBackground = value; }

    public GameObject Map { get => map; set => map = value; }

    

    public List<Material> TileMaterials { get =>tileMaterials; }
    public List<Material> StartMaterials { get => startMaterials; }
    public List<Material> EndMaterials { get =>endMaterials; }
    public List<Material> WallMaterials { get => wallMaterials; }

    private GameManager gameManager;



    private void Awake()
    {
        southWestCorners.Add("Map_9x9", new Vector2(-4, -4));
        southWestCorners.Add("Map_19x19", new Vector2(-9, -9));
        southWestCorners.Add("Map_17x17", new Vector2(-8, -8));
    }

    private void ScaleBackground()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        waveNum = 0;
        wavesCompleted = GameObject.Find("WavesFinished").GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnQueue.Count > 0 && gameManager.Lives >0)
        {
            time += Time.deltaTime;
            if (time > spawnQueue[0].Item2)
            {
                Instantiate(spawnQueue[0].Item1);
                spawnQueue.RemoveAt(0);
                time = 0f;
            }
        }
    }

    public void SendWave()
    {
        float delay = 1;
        waveNum += 1;

        wavesCompleted.text = waveNum.ToString();

        for (int i = 0; i < waveNum*3; i++)
        {
           
            Tuple<EnemyUnit, float> spawnItem = new Tuple<EnemyUnit, float>(enemies[0], delay);
            spawnQueue.Add(spawnItem);
            delay = enemySpawnDelay;
           
            
        }
    }

    public int getWave()
    {
        return waveNum;
    }


   
}
