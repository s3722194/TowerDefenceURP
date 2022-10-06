using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    [SerializeField] private bool chargeUp;
    [SerializeField] private bool chargeDown;
    [SerializeField] private bool chargeConstant;
    [SerializeField] private float speed;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(chargeUp)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, System.MathF.Pow(2, speed* count);
            count++;
        }
    }

    public void ChargeUp()
    {
        chargeUp = true;
        chargeDown = false;
        chargeConstant = false;

    }
}
