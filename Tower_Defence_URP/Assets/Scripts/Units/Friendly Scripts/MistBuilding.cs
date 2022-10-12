using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistBuilding : ABuilding
{
    private const float speedRate = 10.0f;

    public override void Attack()
    {
        // NOT ATTACKING
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    protected override void Update()
    {
        // Update handled through trigger colliders
    }

    new void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyUnit enemy = collider.gameObject.GetComponent<EnemyUnit>();
            if(enemy != null)
            {
                enemy.Speed = enemy.Speed / speedRate;
            }
        }
    }

    new void OnTriggerExit2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyUnit enemy = collider.gameObject.GetComponent<EnemyUnit>();
            if (enemy != null)
            {
                enemy.Speed = enemy.Speed * speedRate;
            }
        }
    }
}
