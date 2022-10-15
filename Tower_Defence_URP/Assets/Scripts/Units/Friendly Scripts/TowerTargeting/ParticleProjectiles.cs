using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleProjectiles : MonoBehaviour
{
    [SerializeField] private Building BlackHoleTower;

    private ParticleSystem ps;
    private List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);

        EnemyUnit enemy = other.GetComponent<EnemyUnit>();
        int i = 0;

        while(i < numCollisionEvents)
        {
            if(enemy)
            {
                enemy.TakeDamage(BlackHoleTower.Damage);
            }
            i++;
        }
    }
}
