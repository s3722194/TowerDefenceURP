using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PathLight : MonoBehaviour
{
    [SerializeField] private GameObject gridLight;
    [SerializeField] private MapGrid grid;
    [SerializeField] private GameObject parentLight;
    [SerializeField] private int length;
    private Dictionary<string, (GameObject, Light2D)> lights = new Dictionary<string, (GameObject, Light2D)>();
    
    [SerializeField] private int updateSpeed = 1000;
    [SerializeField] private int flashSpeed =100;
    
    private int flashIndex = 0;
    
    [SerializeField] private int countUpdatePath;
    [SerializeField] private int countFlash = 0;
    private List<List<Light2D>> pathLights = new List<List<Light2D>>();

    [SerializeField] private float flashIntensity = 3;
    [SerializeField] private float normalIntensity = 2;
    private List<List<Vector2Int>> allPaths = new List<List<Vector2Int>>();
    private Path path;

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
                lights.Add(i+","+j, (newLight, newLight.GetComponent<Light2D>()));
                
                newLight.SetActive(false);

            }
            
        }
        countUpdatePath = updateSpeed;

        flashIndex = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        try
        {
            if (grid.GetNumPaths() != 0)
            {
                UpdatePathLight();
                UpdateFlash();
            }
            else
            {
                if (pathLights.Count > 0)
                {
                    pathLights.Clear();
                }
                
            }
        }
        catch (System.ArgumentOutOfRangeException)
        {
            
        }
        catch (System.NullReferenceException)
        {
            
        }

    }

    private void UpdateFlash()
    {
        UpdateFlashCount();

        if (countFlash >= flashSpeed)
        {
            countFlash = 0;

            // List<GameObject> currentLights = pathLights[flashIndex];
            if (flashIndex == 0)
            {
                foreach (Light2D light in pathLights[pathLights.Count-1])
                {
                    light.intensity = normalIntensity;
                }
            }
            else
            {
                foreach (Light2D light in pathLights[flashIndex-1])
                {
                    light.intensity = normalIntensity;
                }
            }

            foreach (Light2D light in pathLights[flashIndex])
            {
                light.intensity = flashIntensity;
            }


            flashIndex++;
            if (flashIndex == pathLights.Count-1)
            {
                flashIndex = 0;
            }

        }
    }

    private void UpdateFlashCount()
    {
        if (pathLights.Count > 0)
        {
            countFlash++;
        }
    }
    
    private void UpdatePathLight()
    {
        countUpdatePath++;
        if (countUpdatePath >= updateSpeed)
        {
            if(allPaths.Count > 0)
            {
                for (int i = 0; i < grid.GetNumPaths(); i++)
                {
                    path = grid.GetPath(i);
                    List<Vector2Int> positoins = path.GetPositions();
                    
                    if(positoins != allPaths[i])
                    {
                        DeactivateAllLights();
                        pathLights.Clear();
                        FindAllPaths();
                        break;
                    }
                }
                countUpdatePath = 0;
                
            }
            else
            {
                for (int i = 0; i < grid.GetNumPaths(); i++)
                {
                    path = grid.GetPath(i);
                    List<Vector2Int> positoins = path.GetPositions();
                    allPaths.Add(positoins);

                }
                countUpdatePath = 0;
                FindAllPaths();
            }
               
        }
        
    }

    
    private void FindAllPaths()
    {
        for (int i = 0; i < grid.GetNumPaths(); i++)
        {
            path = grid.GetPath(i);
            List<Vector2Int> positoins = path.GetPositions();
            int count = 0;
            foreach (Vector2Int tile in positoins)
            {
                
                AddLightsToList(tile, count);
                ActivateLight(tile);

                if (lights.ContainsKey(tile.x + "," + tile.y))
                {
                    count++;
                }
                    
            }
        }
    }

    private void ActivateLight(Vector2Int tile)
    {
        if (lights.ContainsKey(tile.x + "," + tile.y))
        {
            GameObject currentLight = lights[tile.x + "," + tile.y].Item1;
            currentLight.SetActive(true);
        }

            
    }

    private void AddLightsToList(Vector2Int tile, int index)
    {
        
        if (lights.ContainsKey(tile.x + "," + tile.y))
        {
            
            Light2D currentLight2D = lights[tile.x + "," + tile.y].Item2;
            
            //adds tile by Y position to use for 
            if (pathLights.Count < index)
            {

                pathLights[index].Add(currentLight2D);

            }
            else
            {
                pathLights.Add( new List<Light2D>());
                pathLights[index].Add(currentLight2D);
            }

          
        }
    }

    private void DeactivateAllLights()
    {
        foreach (List<Light2D> light in pathLights)
        {
            foreach(Light2D newlight in light)
            {
                //light.SetActive(false);
                newlight.gameObject.SetActive(false);

            }
            
        }
    }
}
