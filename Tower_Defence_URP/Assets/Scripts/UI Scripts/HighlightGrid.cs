using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightGrid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool mouseDrag = false;
    [SerializeField]
    private Color highlightColour = new Color(99.0f / 255.0f, 106.0f / 255.0f, 117.0f / 255.0f);
    [SerializeField]
    private Color baseColour;
    [SerializeField]
    private Color hoverColour = new Color(188.0f / 255.0f, 198.0f / 255.0f, 214.0f / 255.0f);


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColour = spriteRenderer.material.GetColor("_Color");
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDrag()
    {
        print("Mouse Drag");
        mouseDrag = true;
        //  spriteRenderer.color = new Color(29.0f / 255.0f, 27.0f / 255.0f, 27.0f / 255.0f, 1.0f);
    }

    public void OnMouseDown()
    {
        spriteRenderer.material.SetColor("_Color", highlightColour);
    }

    public void OnMouseUp()
    {

        spriteRenderer.material.SetColor("_Color", hoverColour);
        mouseDrag = false;
    }

    public void OnMouseEnter()
    {
        //print("Tile: " + x + " ," + y +" "+ "Mouse Enter");
        spriteRenderer.material.SetColor("_Color", hoverColour);
        // spriteRenderer.color = Color.red;
    }

    public void OnMouseExit()
    {
        //print("Tile: " + x + " ," + y + " " + "Mouse Exit");
        spriteRenderer.material.SetColor("_Color", baseColour);
        // spriteRenderer.color = Color.black;
    }
}
