using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLight : MonoBehaviour
{
    [SerializeField] private GameObject gridLight;
    [SerializeField] private MapGrid grid;
    [SerializeField] private GameObject parentLight;
    [SerializeField] private int length;
    private Dictionary<string, GameObject> lights = new Dictionary<string, GameObject>();
    [SerializeField] private int updateSpeed = 1000;
    [SerializeField] private int flashSpeed =1000;
    [SerializeField] private GameObject previousLight =null;
    private int flashIndex = 0;
    // private ArrrayList<Path> oldpath =null;
    private int countUpdatePath = 0 ;
    private int countFlash = 0;
    private Dictionary<int, List<GameObject>> pathLights = new Dictionary<int, List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject newLight;
        for (int i = 1; i <= length; i++)
        {
            for (int j =1; j<=length; j++)
            {
                newLight = Instantiate(gridLight);
                newLight.transform.position = new Vector3(i, j, newLight.transform.position.z);
                newLight.transform.parent = parentLight.transform;
                lights.Add(i+","+j, newLight);
                
                newLight.SetActive(false);

            }
            
        }
        countUpdatePath = updateSpeed;
        flashIndex = length;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(grid.GetNumPaths() != 0)
        {
            countUpdatePath++;
            if (countUpdatePath == 200)
            {
                countUpdatePath = 0;

                foreach (GameObject light in lights.Values)
                {
                    light.SetActive(false);
                }
                pathLights.Clear();
                for (int i = 0; i < grid.GetNumPaths(); i++)
                {
                    Path path = grid.GetPath(i);
                    List<Vector2Int> positoins = path.GetPositions();
                    foreach (Vector2Int tile in positoins)
                    {
                        if(lights.ContainsKey(tile.x + "," + tile.y))
                        {
                            GameObject currentLight = lights[tile.x + "," + tile.y];

                            //adds tile by Y position
                            if (pathLights.ContainsKey(tile.y)){

                                pathLights[tile.y].Add(currentLight);

                            }
                            else
                            {
                                pathLights.Add(tile.y, new List<GameObject>());
                                pathLights[tile.y].Add(currentLight);
                            }
                            
                            currentLight.SetActive(true);
                        }
                        
                    }
                }
            }
            else
            {
                if (pathLights.Count > 0)
                {
                    pathLights.Clear();
                }
            }


            if(pathLights.Count > 0)
            {
                countFlash++;
            }

            if(countFlash == flashSpeed)
            {
                countFlash = 0;

                foreach (GameObject light in pathLights.[flashIndex])
                {
                   // light.GetComponent<Light2D>();
                }


                flashIndex--;
                if(flashIndex == 0)
                {
                    flashIndex = length;
                }

            }
           
        }
      
    }
}
