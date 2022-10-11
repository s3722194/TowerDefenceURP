using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFog : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private Vector4 noiseOffset;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (materials.Count != 0)
        {
            Material mat = materials[Random.Range(0, materials.Count)];
            spriteRenderer.material = mat;
            float minNoise = Random.Range(noiseOffset.x, noiseOffset.y);
            float maxNoise = Random.Range(noiseOffset.z, noiseOffset.w);

            spriteRenderer.material.SetVector("_NoiseOffset", new Vector4(minNoise, maxNoise));
        }


        }

    // Update is called once per frame
  
}
