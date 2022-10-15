using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicBuilding : Building
{
    public override void Attack()
    {
        // Fire a bullet every [AttackCooldown] seconds
        if (FireRate >= AttackCooldown)
        {
            for(int i = 0; i < enemiesInRange.Count; i++)
            {
                _ = Projectile.Spawn(ProjectilePrefab, this.transform.position, this.transform.rotation, enemiesInRange[i].transform, Damage);
            }

            audioManager.PlaySound(sound);
            FireRate = 0.0f;
        }
        else
        {
            FireRate += Time.deltaTime;
        }
    }
}
