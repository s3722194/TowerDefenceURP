using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Material basicDamage;
    [SerializeField] private Material toxicDamage;
    [SerializeField] private Material fireDamage;
    [SerializeField] private Material blackHoleDamage;
    [SerializeField] private Material fogDamage;
    [SerializeField] private Material orbDamage;
    [SerializeField] private Material lazerDamage;
    [SerializeField] private Material deathLazerDamage;

    [SerializeField] private bool takingToxicDamage;
    [SerializeField] private bool takingFogDamage;
    [SerializeField] private bool takingBlackHoleDamage;
    [SerializeField] private bool takingBasicDamage;
    [SerializeField] private bool takingFireDamage;
    [SerializeField] private bool takingDeathLazerDamage;
    [SerializeField] private bool takingLazerDamage;
    [SerializeField] private bool takingOrbDamage;

    [SerializeField] private bool isBlink;
    [SerializeField] private bool isAttack;
    [SerializeField] private bool isCastSpell;
    [SerializeField] private bool isDying;
    [SerializeField] private bool isDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
