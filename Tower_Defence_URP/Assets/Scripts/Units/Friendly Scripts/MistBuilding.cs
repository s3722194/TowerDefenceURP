using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistBuilding : Building
{
    [SerializeField] private float slowDownRate;

    public override void Attack()
    {
        // NOT ATTACKING
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
                enemy.Speed /= slowDownRate;
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
                enemy.Speed *= slowDownRate;
            }
        }
    }
}
