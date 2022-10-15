using UnityEngine;

public class DeathRayBuilding : Building
{
    public override void Attack()
    {
        // Deal damage over time every increment of set time
        if (FireRate >= AttackCooldown)
        {
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                EnemyUnit enemy = enemiesInRange[i].gameObject.GetComponent<EnemyUnit>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                }
            }
            FireRate = 0.0f;
            audioManager.PlaySound(sound);
        }
        else
        {
            FireRate += Time.deltaTime;
        }
    }
}
