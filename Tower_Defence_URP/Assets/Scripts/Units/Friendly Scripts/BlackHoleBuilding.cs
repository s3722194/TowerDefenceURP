using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBuilding : ABuilding
{
    public override void Attack()
    {
        //Do Nothing
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    protected override void Update()
    {
        //Do Nothing
    }
}
