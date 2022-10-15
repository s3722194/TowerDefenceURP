using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstBuilding : Building
{
    public override void Attack()
    {
        // Fire a bullet every [AttackCooldown] seconds
        if(FireRate >= AttackCooldown)
        {
            // Debug.Log("spawning projectile");
            _ = Projectile.Spawn(ProjectilePrefab, this.transform.position, this.transform.rotation, enemiesInRange[0].transform, Damage);
            FireRate = 0.0f;
            audioManager.PlaySound(AudioManager.Sound.Orb);
        }
        else
        {
            FireRate += Time.deltaTime;
        }
    }
}
