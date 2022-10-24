using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : AUnit
{
    [SerializeField] protected bool destructable;
    [SerializeField] [Min(0)] protected int cost;
    [SerializeField] [Min(0.0f)] protected float upgradeCostRate = 0.5f;
    [SerializeField] protected GameObject ProjectilePrefab;
    [SerializeField] protected AudioManager.Sound sound;

    [SerializeReference] private bool upgradeable;
    [SerializeReference] protected int upgradeCost;

    //Store a list of enemies that come into range of a tower
    public List<GameObject> enemiesInRange;

    public int Cost { get => cost; set => cost = value; }
    public int UpgradeCost { get => upgradeCost; set => upgradeCost = value; }
    public float FireRate { get; protected set; }
    public bool Upgradeable { get => upgradeable; protected set => upgradeable = value; }

    public Building() : base()
    {
        enemiesInRange = new List<GameObject>();
    }

    protected override void Start()
    {
        base.Start();
        UpgradeCost = (int)(Cost * upgradeCostRate);
        FireRate = AttackCooldown;

        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if (collider)
        {
            collider.radius = Range;
        }
    }

    protected override void Update()
    {
        if (enemiesInRange.Count > 0)
        {
            Attack();
        }
        else
        {
            FireRate = AttackCooldown;
        }
    }

    public override void Attack()
    {
        // Fire a bullet every [AttackCooldown] seconds
        if (AttackCooldown <= 0)
        {
            return;
        }
        if (FireRate >= AttackCooldown)
        {
            GameObject target = SelectTarget();
            if (target != null)
            {
                _ = Projectile.Spawn(ProjectilePrefab, transform.position, transform.rotation, enemiesInRange[0].transform, Damage);
                FireRate = 0.0f;
                audioManager.PlaySound(sound);
            }
        }
        else
        {
            FireRate += Time.deltaTime;
        }
    }

    public GameObject SelectTarget()
    {
        List<EnemyUnit> oldEnemies = new List<EnemyUnit>();
        GameObject target = null;
        for (int i = 0; i < enemiesInRange.Count; i++)
        {
            EnemyUnit enemy = enemiesInRange[i].GetComponent<EnemyUnit>();
            if (enemy)
            {
                if (enemy.IsDying)
                {
                    oldEnemies.Add(enemy);
                }
                else
                {
                    target = enemy.gameObject;
                    break;
                }
            }
            else
            {
                oldEnemies.Add(enemy);
            }
        }
        foreach (EnemyUnit enemy in oldEnemies)
        {
            enemiesInRange.Remove(enemy.gameObject);
        }
        return target;
    }

    public override bool TakeDamage(int damage)
    {
        if (destructable)
        {
            return base.TakeDamage(damage);
        }
        return false;
    }

    protected void OnTriggerEnter2D (Collider2D other)
    {
        // Add enemies to the list of enemies a tower can target within its range
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    protected void OnTriggerExit2D (Collider2D other)
    {
        // Remove enemies from the list that exits a tower's range
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
