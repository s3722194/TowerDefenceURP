using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float movementSpeed = 5.5f;
    private float radius = 1.0f;
    private float radiusSq;

    Transform target;

    void OnEnable()
    {
        radiusSq = radius * radius;
    }

    // Update is called once per frame
    void Update()
    {
        if(!target)
        {
            Debug.Log("no enemy to target");
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - this.transform.position;
        transform.position += direction.normalized * movementSpeed * Time.deltaTime;

        if(direction.sqrMagnitude < radiusSq)
        {
            Debug.Log("enemy hit");
            Destroy(gameObject);
        }
    }

    public static Projectile Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform _target)
    {
        GameObject spawnProjectile = Instantiate(prefab, position, rotation);
        Projectile sp = spawnProjectile.GetComponent<Projectile>();

        if(!sp)
        {
            sp = spawnProjectile.AddComponent<Projectile>();
        }

        sp.target = _target;
        return sp;
    }
}
