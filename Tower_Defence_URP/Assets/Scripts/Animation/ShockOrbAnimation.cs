using UnityEngine;

public class ShockOrbAnimation : MonoBehaviour
{
    [SerializeField] private bool shake;
    private SpriteRenderer sr;
    private Color colour2;
    [SerializeField] private float radis;
    [SerializeField] private float speed;
    private Vector2 startPosition;
     private Vector2 startLerp;
     private Vector2 EndLerp;
     
     private float count;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startLerp = transform.position;
        EndLerp = transform.position;
        startPosition = transform.position;
        count = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shake)
        {
            float currentX = (float)System.Math.Round(transform.position.x, 2);
            float currentY = (float) System.Math.Round(transform.position.y, 2);
            float endX = (float)System.Math.Round(EndLerp.x, 2); 
            float endY = (float)System.Math.Round(EndLerp.y, 2);
            if (currentX == endX && currentY == endY)
            {
                startLerp = EndLerp;
                float x= startPosition.x;
                float y= startPosition.y;
                // float z= transform.position.z;
                EndLerp = new Vector2(Random.Range(x - radis, x + radis), Random.Range(y - radis, y + radis));
                count = 0;
            }
            transform.position = Vector3.Lerp(startLerp, EndLerp, speed * count);
            count++;
        }
        
    }
}
