using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadToxic : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private Vector2 vorSpeed;
    [SerializeField] private Vector2 vorAngleSpeed;
    [SerializeField] private Vector2 ripleTime;
    [SerializeField] private Vector2 vorScale;
    [SerializeField] private Vector2 vorPower;
    [SerializeField] private Vector2 noisePower;
    [SerializeField] private Vector2 noiseScale;
    [SerializeField] private Vector4 noiseOffset;
    [SerializeField] private Vector4 vorOffset;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (materials.Count != 0)
        {
            Material mat = materials[Random.Range(0, materials.Count)];
            spriteRenderer.material = mat;
            float newVorSpeed = Random.Range(vorSpeed.x, vorSpeed.y);
            float newVorAngleSpeed = Random.Range(vorAngleSpeed.x, vorAngleSpeed.y);
            float newRiplieTime = Random.Range(ripleTime.x, ripleTime.y);
            float newVorPower = Random.Range(vorPower.x, vorPower.y);
            float newVorScale = Random.Range(vorScale.x, vorScale.y);
            float newNoisePower = Random.Range(noisePower.x, noisePower.y);
            float newNoiseScale = Random.Range(noiseScale.x, noiseScale.y);
            float minNoiseOffset = Random.Range(noiseOffset.x, noiseOffset.y);
            float maxNoiseOffset = Random.Range(noiseOffset.z, noiseOffset.w);
            float minVorOffset = Random.Range(vorOffset.x, vorOffset.y);
            float maxVorOffset = Random.Range(vorOffset.z, vorOffset.w);

            spriteRenderer.material.SetVector("_VorSpeed", new Vector2(0, newVorSpeed));
            spriteRenderer.material.SetFloat("_VorAngleSpeed", newVorAngleSpeed);
            spriteRenderer.material.SetVector("_RipleTime", new Vector2(0, newRiplieTime));
            spriteRenderer.material.SetFloat("_VorPower", newVorPower);
            spriteRenderer.material.SetFloat("_VorScale", newVorScale);
            spriteRenderer.material.SetFloat("_NoisePower", newNoisePower);
            spriteRenderer.material.SetFloat("_NoiseScale", newNoiseScale);
            spriteRenderer.material.SetVector("_NoiseOffset", new Vector2(minNoiseOffset, maxNoiseOffset));
            spriteRenderer.material.SetVector("_VorOffset", new Vector2(minVorOffset, maxVorOffset));


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
