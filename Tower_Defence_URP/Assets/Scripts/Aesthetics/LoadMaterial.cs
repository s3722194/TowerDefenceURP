using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMaterial : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (materials.Count != 0)
        {
            spriteRenderer.material = materials[Random.Range(0, materials.Count)];
        }
    }


}
