using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGrid : MonoBehaviour
{

    private LevelManager levelManager;
    private Vector2 southWestCorner;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        SetUpScene();
    }

    private void SetUpScene()
    {
        Instantiate(levelManager.Background);
        Instantiate(levelManager.GridBackground);
        Instantiate(levelManager.Map);
        SetUpMaterials();
    }

    private void SetUpMaterials()
    {
        if( !levelManager.Map.Equals("Untagged"))
        {
            southWestCorner = levelManager.SouthWestCorners[levelManager.Map.tag];
        }
        

        SetUpGridMaterial();
        SetUpWallMaterials();
        SetUpStartMaterials();
        SetUpEndMaterials();

    }

    private void SetUpStartMaterials()
    {
        GameObject start = GameObject.FindGameObjectWithTag("Start");
        List<Material> materials = levelManager.StartMaterials;

        foreach (Transform child in start.transform)
        {
            SpriteRenderer sr = child.gameObject.GetComponent<SpriteRenderer>();
            sr.color = Color.white;
            sr.material = materials[Random.Range(0, materials.Count)];
        }
    }

    private void SetUpEndMaterials()
    {
        GameObject end = GameObject.FindGameObjectWithTag("End");
        List<Material> materials = levelManager.EndMaterials;

        foreach (Transform child in end.transform)
        {
            SpriteRenderer sr = child.gameObject.GetComponent<SpriteRenderer>();
            sr.color = Color.white;
            sr.material = materials[Random.Range(0, materials.Count)];
        }
    }

    private void SetUpWallMaterials()
    {
        GameObject wall = GameObject.FindGameObjectWithTag("Wall");
        List<Material> materials = levelManager.WallMaterials;

        foreach (Transform child in wall.transform)
        {
            SpriteRenderer sr = child.gameObject.GetComponent<SpriteRenderer>();
            sr.color = Color.white;
            sr.material = materials[Random.Range(0, materials.Count)];
        }
    }

    private void SetUpGridMaterial()
    {
        float x = southWestCorner.x;
        float y = southWestCorner.y;

        GameObject grid = GameObject.FindGameObjectWithTag("Grid");
        List<Material> materials = levelManager.TileMaterials;

        foreach (Transform child in grid.transform)
        {

            GridTile tile = child.GetComponent<GridTile>();
            if (tile != null)
            {
                //print(child.name);

                float newX = child.transform.position.x - x;
                float newY = child.transform.position.y - y;

                // in tranform sometimes numbers get store as 0.999999 even tho its practically 1
                // so i need to ceil it
                tile.x = (int)Mathf.Ceil(newX);
                tile.y = (int)Mathf.Ceil(newY);
                tile.nodeSize = 1;
                SpriteRenderer sr = child.gameObject.GetComponent<SpriteRenderer>();
                
                sr.color = Color.white;
                
                sr.material = materials[Random.Range(0, materials.Count)];

            }
        }
    }
}
