using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBuilding : Building
{
    public override void Attack()
    {
        audioManager.PlaySound(sound);
    }

    protected override void Update()
    {
        //Do Nothing
    }
}
