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

    private float time;
    private GameObject ui;
    //private GameObject managers;

    [SerializeField] private int delayStart;

    public GameObject Background { get => background; set => background = value; }
    public GameObject GridBackground { get => gridBackground; set => gridBackground = value; }

    public GameObject Map { get => map; set => map = value; }


  


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
