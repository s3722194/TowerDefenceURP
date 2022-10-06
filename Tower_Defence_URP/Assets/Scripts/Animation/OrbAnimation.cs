using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAnimation : MonoBehaviour
{
    [SerializeField] private float speed;
    /*[ColorUsage(true, true)][SerializeField] private Color color1;
    [ColorUsage(true, true)][SerializeField] private Color color2;*/
    private SpriteRenderer spriteRenderer;
    private bool changeColor = true;
    [SerializeField] private float startHue;
    [SerializeField] private float endHue;
    [ColorUsage(true, true)] [SerializeField] private Color newColor;
    [SerializeField] private float count;
    [SerializeField] private float intensity;
    [SerializeField] private float newHue;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        count = Random.Range(0,1.0f/speed);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (changeColor)
        {
            Color colour2 = spriteRenderer.material.GetColor("_Color_2");
            newColor = colour2;
            float h, s, v;
            Color.RGBToHSV(colour2, out h, out s, out v);
            newHue= Lerp(startHue, endHue, count * speed);
            count++;
            
            newColor = Color.HSVToRGB(newHue / 360.0f, s, v);
           /* newColor.r *= intensity;
            newColor.g *= intensity;
            newColor.b *= intensity;*/

            spriteRenderer.material.SetColor("_Color_2", newColor);

            if (newHue > endHue)
            {
                count = 0;
            }

        }
    }

    private float Lerp(float a, float b, float t)
    {
       return a + (b - a) * t;
    }
}
