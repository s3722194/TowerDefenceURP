using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABuilding : AUnit
{
    [SerializeField] private bool destructable;
    [SerializeField] private int cost;

    public int Cost { get => cost; set => cost = value; }

    protected override void Start()
    {
        base.Start();
    }

    //Store a list of enemies that come into range of a tower
    public List<GameObject> EnemiesInRange;

    public ABuilding() : base()
    {
        EnemiesInRange = new List<GameObject>();
    }

    public override bool TakeDamage(int damage)
    {
        if (destructable)
        {
            return base.TakeDamage(damage);
        }
        return false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //Add enemies to the list of enemies a tower can target within its range
        if(other.gameObject.tag.Equals("Enemy"))
        {
            EnemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        //Remove enemies from the list that exits a tower's range
        if(other.gameObject.tag.Equals("Enemy"))
        {
            EnemiesInRange.Remove(other.gameObject);
        }
    }
}
