using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightGrid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Color highlightColour;
    
    private Color baseColour;
    [SerializeField]
    private Color hoverColour;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColour = spriteRenderer.material.GetColor("_Color");
    }

    public void OnMouseDown()
    {
        spriteRenderer.material.SetColor("_Color", highlightColour);
    }

    public void OnMouseUp()
    {
        spriteRenderer.material.SetColor("_Color", hoverColour);
    }

    public void OnMouseEnter()
    {
        // print("Tile: " + x + " ," + y +" "+ "Mouse Enter");
        spriteRenderer.material.SetColor("_Color", hoverColour);
    }

    public void OnMouseExit()
    {
        // print("Tile: " + x + " ," + y + " " + "Mouse Exit");
        spriteRenderer.material.SetColor("_Color", baseColour);
    }
}
