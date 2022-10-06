using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAnimation : MonoBehaviour
{
    [SerializeField] private float speed;
    [ColorUsage(true, true)][SerializeField] private Color color1;
    [ColorUsage(true, true)][SerializeField] private Color color2;
    private SpriteRenderer spriteRenderer;
    private bool changeColor = true;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (changeColor)
        {

        }
    }
}
