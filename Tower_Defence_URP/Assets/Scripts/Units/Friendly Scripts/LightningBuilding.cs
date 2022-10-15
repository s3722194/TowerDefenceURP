using UnityEngine;

public class LightningBuilding : Building
{
    public GameObject firstLightning;
    public GameObject secondLightning;
    public GameObject thirdLightning;

    public override void Attack()
    {
        // Fire a bullet every [AttackCooldown] seconds
        if (FireRate >= AttackCooldown)
        {
            int firstTarget = (int) Random.Range(0, enemiesInRange.Count - 1);
            int secondTarget = (int) Random.Range(0, enemiesInRange.Count - 1);
            int thirdTarget = (int) Random.Range(0, enemiesInRange.Count - 1);

            _ = LightningProjectile.Spawn(firstLightning, this.transform.position, this.transform.rotation, enemiesInRange[firstTarget].transform, Damage);
            _ = LightningProjectile.Spawn(secondLightning, this.transform.position, this.transform.rotation, enemiesInRange[secondTarget].transform, Damage);
            _ = LightningProjectile.Spawn(thirdLightning, this.transform.position, this.transform.rotation, enemiesInRange[thirdTarget].transform, Damage);

            audioManager.PlaySound(AudioManager.Sound.Chain);

            FireRate = 0.0f;
        }
        else
        {
            FireRate += Time.deltaTime;
        }
    }
}
