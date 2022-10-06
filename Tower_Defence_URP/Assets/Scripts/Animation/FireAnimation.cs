using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    [SerializeField] private bool chargeUp;
    [SerializeField] private bool chargeDown;
    [SerializeField] private bool chargeConstant;
    [SerializeField] private float speedUp;
    [SerializeField] private float count;
    public float rotation =0;
    [SerializeField] private float speedConstant;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (chargeUp)
        {
            rotation = System.MathF.Pow(2, speedUp * count);
            transform.rotation = Quaternion.Euler(0f, 0f, rotation % 360);
            count++;
            if (rotation > 10000)
            {
                chargeUp = false;
                chargeConstant = true;
                count = 0;
            }
        }

        if (chargeConstant)
        {

            transform.rotation = Quaternion.Euler(0f, 0f, (speedConstant * count) % 360);
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
