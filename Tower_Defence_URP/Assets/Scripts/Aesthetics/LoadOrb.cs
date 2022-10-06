using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOrb : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private Vector2 colourHue;
    [SerializeField] private Vector2 colourSaturation;
    [SerializeField] private Vector2 colourValue;
    [SerializeField] private Vector2 secondColourRange;
    [SerializeField] private Vector2 power1;
    [SerializeField] private Vector2 power2;
    [SerializeField] private Vector2 noiseSpeed;
    [SerializeField] private Vector2 noiseTime;
    [SerializeField] private Vector2 cellSpeed;
    [SerializeField] private Vector2 noisePower;
    [SerializeField] private Vector2 noiseCell;
    [SerializeField] private Vector4 noiseOffset;
    [ColorUsage(true, true)]
    [SerializeField] private Color colour1;
    [ColorUsage(true, true)]
    [SerializeField] private Color colour2;
    [SerializeField] private float intensity;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (materials.Count != 0)
        {
            Material mat = materials[Random.Range(0, materials.Count)];
            spriteRenderer.material = mat;
            float newColourHue = Random.Range(colourHue.x, colourHue.y);
            float newColourSaturation = Random.Range(colourSaturation.x, colourSaturation.y);
            float newColourValue = Random.Range(colourValue.x, colourValue.y);
            float newSecondHue = Random.Range(newColourHue+secondColourRange.x, newColourHue+secondColourRange.y);
            float newPower1 = Random.Range(power1.x, power1.y);
            float newPower2 = Random.Range(power2.x, power2.y);
            float newNoiseSpeed = Random.Range(noiseSpeed.x, noiseSpeed.y);
            float newNoiseTime = Random.Range(noiseTime.x, noiseTime.y);
            float newCellSpeed = Random.Range(cellSpeed.x, cellSpeed.y);
            float newNoisePower = Random.Range(noisePower.x, noisePower.y);
            float newNoiseCell = Random.Range(noiseCell.x, noiseCell.y);
            float minNoiseOffset = Random.Range(noiseOffset.x, noiseOffset.y);
            float maxNoiseOffset = Random.Range(noiseOffset.z, noiseOffset.w);

            if(newSecondHue < 0)
            {
                newSecondHue += 360;
            }

            Color newColour1 = Color.HSVToRGB(newColourHue/360.0f , newColourSaturation/100.0f, newColourValue/100.0f);
            Color newColour2 = Color.HSVToRGB(newSecondHue/360.0f, newColourSaturation/100.0f, newColourValue/100.0f);

            
            colour1.r = newColour1.r *intensity;
            colour1.g = newColour1.g * intensity;
            colour1.b = newColour1.b * intensity;
            
            colour2.r = newColour2.r * intensity;
            colour2.g = newColour2.g * intensity;
            colour2.b = newColour2.b * intensity;
            spriteRenderer.material.SetColor("_Color_1", colour1);
            spriteRenderer.material.SetColor("_Color_2", colour2);
            spriteRenderer.material.SetFloat("_Power_1", newPower1);
            spriteRenderer.material.SetFloat("_Power_2", newPower2);
            spriteRenderer.material.SetVector("_NoiseSpeed", new Vector2(0, newNoiseSpeed));
            spriteRenderer.material.SetVector("_NoiseTime", new Vector2(newNoiseTime, newNoiseTime));
            spriteRenderer.material.SetFloat("_CellSpeed", newCellSpeed);
            spriteRenderer.material.SetFloat("_NoisePower", newNoisePower);
            spriteRenderer.material.SetFloat("_NoiseCell", newNoiseCell);
            spriteRenderer.material.SetVector("_NoiseOffset", new Vector2(minNoiseOffset, maxNoiseOffset));



        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
