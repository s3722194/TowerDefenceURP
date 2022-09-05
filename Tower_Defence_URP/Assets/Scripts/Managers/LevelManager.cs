using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    

    //to calcualte the x and y corrdinates for the game
    
    private Dictionary<string, Vector2> southWestCorners = new Dictionary<string, Vector2>();

    private float time;
    private GameObject ui;
    //private GameObject managers;

    [SerializeField] private int delayStart;

    
    public Dictionary<string, Vector2> SouthWestCorners { get => southWestCorners; }
    public GameObject Background { get => background; set => background = value; }
    public GameObject GridBackground { get => gridBackground; set => gridBackground = value; }

    public GameObject Map { get => map; set => map = value; }

    

    public List<Material> TileMaterials { get =>tileMaterials; }
    public List<Material> StartMaterials { get => startMaterials; }
    public List<Material> EndMaterials { get =>endMaterials; }
    public List<Material> WallMaterials { get => wallMaterials; }





    private void Awake()
    {
        southWestCorners.Add("Map_9x9", new Vector2(-4, -4));
        southWestCorners.Add("Map_19x19", new Vector2(-4, -14));
    }

    // Start is called before the first frame update
    void Start()
    {
        
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > delayStart)
        {
            // Start sending waves
        }
    }

   
}
