using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadShock : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private Vector4 elecitrySpeed;
    [SerializeField] private Vector2 electiryScale;
    [SerializeField] private Vector2 lineWeight;
    [SerializeField] private Vector2 noiseScale;
    [SerializeField] private Vector2 noiseSpeed;
    [SerializeField] private Vector4 electiryOffset;
    [SerializeField] private Vector4 noiseOffset;
    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (materials.Count != 0)
        {
            Material mat = materials[Random.Range(0, materials.Count)];
            spriteRenderer.material = mat;
            float newElecitrySpeedX = Random.Range(elecitrySpeed.x, elecitrySpeed.y);
            float newElecitrySpeedY = Random.Range(elecitrySpeed.z, elecitrySpeed.w);
            float newElectiryScale = Random.Range(electiryScale.x, electiryScale.y);
            float newLineWeight = Random.Range(lineWeight.x, lineWeight.y);
            float newNoiseScale = Random.Range(noiseScale.x, noiseScale.y);
            float newNoiseSpeedY = Random.Range(noiseSpeed.x, noiseSpeed.y);
            float minElectiryOffset = Random.Range(electiryOffset.x, electiryOffset.y);
            float maxElectiryOffset = Random.Range(electiryOffset.z, electiryOffset.w);
            float  minNoiseOffset = Random.Range(noiseOffset.x, noiseOffset.y);
            float maxNoiseOffset = Random.Range(noiseOffset.z, noiseOffset.w);

            spriteRenderer.material.SetVector("_ElecitrySpeed", new Vector2(newElecitrySpeedX, newElecitrySpeedY));
            spriteRenderer.material.SetFloat("_ElectiryScale", newElectiryScale);
            spriteRenderer.material.SetFloat("_LineWeight", newLineWeight);
            spriteRenderer.material.SetFloat("_NoiseScale", newNoiseScale);
            spriteRenderer.material.SetVector("_NoiseSpeed", new Vector2(0, newNoiseSpeedY));
            spriteRenderer.material.SetVector("_ElectiryOffset", new Vector2(minElectiryOffset, maxElectiryOffset));
            spriteRenderer.material.SetVector("_NoiseOffset",  new Vector2(minNoiseOffset, maxNoiseOffset));
        }

        }


}
