using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFire : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private Vector2 fireTimeY;
    [SerializeField] private Vector2 noiseScale;
    [SerializeField] private Vector2 ashesTimeY;
    [SerializeField] private Vector2 ashesScale;
    [SerializeField] private Vector2 ashesAngle;
    [SerializeField] private Vector4 noiseOffset;
    [SerializeField] private Vector4 ashesOffset;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(materials.Count != 0)
        {
            Material mat = materials[Random.Range(0, materials.Count)];
            spriteRenderer.material = mat;
            spriteRenderer.material.SetFloat("_NoiseScale", Random.Range(noiseScale.x, noiseScale.y));
            spriteRenderer.material.SetFloat("_AshesScale", Random.Range(ashesScale.x, ashesScale.y));
            spriteRenderer.material.SetFloat("_AshesAngle", Random.Range(ashesAngle.x, ashesAngle.y));
            spriteRenderer.material.SetVector("_FireTme", new Vector2(0, Random.Range(fireTimeY.x, fireTimeY.y)));
            spriteRenderer.material.SetVector("_AshesTimeY", new Vector2(-0.1f,Random.Range(ashesTimeY.x, ashesTimeY.y)));
            spriteRenderer.material.SetVector("_NoiseOffset", new Vector2(Random.Range(noiseOffset.x, noiseOffset.y),
                Random.Range(noiseOffset.z, noiseOffset.w)));
            spriteRenderer.material.SetVector("_AshesOffset", new Vector2(Random.Range(ashesOffset.x, ashesOffset.y),
                Random.Range(ashesOffset.z, ashesOffset.w)));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
