using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPortal : MonoBehaviour
{

    [SerializeField]
    private List<Material> materials = new List<Material>();
    [ColorUsage(true, true)]
    [SerializeField] private Color minColor;
    [ColorUsage(true, true)]
    [SerializeField] private Color maxColor;
    [SerializeField] private Vector2 minSpeed;
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 angle;
    [SerializeField] private Vector2 twirlScale;
    [SerializeField] private Vector2 twirlStrength;
    [SerializeField] private Vector2 rotation;
    private SpriteRenderer spriteRenderer;


   



    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (materials.Count != 0)
        {
            Material mat = materials[Random.Range(0, materials.Count)];

            spriteRenderer.material = mat;
            NewSpeed();
            NewAngle();
            NewTwirlScale();
            NewTwirlStrength();
            NewColour();
            NewRotation();

        }

    }

    private void NewRotation()
    {
        float newRotation = Random.Range(rotation.x, rotation.y);
        transform.rotation = Quaternion.Euler(0, 0, newRotation);
    }

    private void NewTwirlStrength()
    {
        float newTwirlStrength = Random.Range(twirlStrength.x, twirlStrength.y);
        //print(name + ". twirl strength: "+ twirlStrength);
        spriteRenderer.material.SetFloat("_TwirlStrength", newTwirlStrength);
    }

    private void NewTwirlScale()
    {
        float twirl = Random.Range(twirlScale.x, twirlScale.y);
        //print(name + ". twirl: " + twirl);
        spriteRenderer.material.SetFloat("_TwirlScale", twirl);
    }

    private void NewAngle()
    {
        float newAngle = Random.Range(angle.x, angle.y);
        // print(name + ". angle: " + newAngle);
        spriteRenderer.material.SetFloat("_Angle", newAngle);
    }

    private void NewSpeed()
    {
        Vector2 speed = new Vector2(Random.Range(minSpeed.x, maxSpeed.x), Random.Range(minSpeed.y, maxSpeed.y));
        // print(name + ". speed: " + speed);
        spriteRenderer.material.SetVector("_Speed", speed);
    }

    private void NewColour()
    {
        float minH, maxH, minS, maxS, minV, maxV;
        Color.RGBToHSV(minColor, out minH, out minS, out minV);
        Color.RGBToHSV(maxColor, out maxH, out maxS, out maxV);
        float hue = Random.Range(minH, maxH);
        float sat = Random.Range(minS, maxS);
        float lightness = Random.Range(minV, maxV);
        Color newColour = Color.HSVToRGB(hue, sat, lightness);
        print("Color: " + newColour);
        spriteRenderer.material.SetColor("_Color", newColour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
