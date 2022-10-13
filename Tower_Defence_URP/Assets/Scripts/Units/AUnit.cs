using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AUnit : MonoBehaviour
{
    [SerializeReference] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float attackCooldown;
    [SerializeField] private int mDamage;
    [SerializeField] private int rDamage;
    [SerializeField] private float range;
    [SerializeField] private string unitName;

    protected AudioManager audioManager;

    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; protected set => maxHealth = value; }
    public float Speed { get => speed; set => speed = value; }
    public float AttackCooldown { get => attackCooldown; protected set => attackCooldown = value; }
    public int MDamage { get => mDamage; set => mDamage = value; }
    public int RDamage { get => rDamage; protected set => rDamage = value; }
    public float Range { get => range; protected set => range = value; }
    public string UnitName { get => unitName; protected set => unitName = value; }

    protected virtual void Start()
    {
        Health = MaxHealth;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    protected abstract void Update();

    /// <summary>
    /// Determines damage to be applied based on type of attack. Manages own cooldown.
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// Performs calculation with armour to determine actual damage taken. Uses Damage class. Returns true if damage killed unit. Damage must be positive
    /// </summary>
    /// <param name="damage"></param>
    public virtual bool TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }
        Health -= damage;
        if (Health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    public abstract void Die();
}
