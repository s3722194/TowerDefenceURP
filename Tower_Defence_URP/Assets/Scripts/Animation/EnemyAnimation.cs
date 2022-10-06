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
    [SerializeField] private bool isHurt;
    [SerializeField] private bool isTaunt;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isIdle;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        TestAnimation();
        
    }

    private void TestAnimation()
    {
        if (isBlink)
        {
            IsBlink();
        } 
        else if (isAttack)
        {
            IsAttack();
        } 
        else if (isTaunt)
        {
            IsTaunt();
        } 
        else if (isDying)
        {
            IsDying();
        } 
        else if (isWalking)
        {
            IsWalking();
        } 
        else if (isCastSpell)
        {
            IsCastSpell();
        } 
        else if (isHurt)
        {
            IsHurt();
        }
        else if (isIdle)
        {
            IsIdle();
        }
        else
        {
            IsIdle();
        }
    }

    public void IsBlink()
    {
        animator.SetBool("IsBlink", true);

        //animator.SetBool("IsBlink", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsCastSpell", false);
        animator.SetBool("IsDying", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsTaunt", false);
        animator.SetBool("IsWalking", false);
    }

    public void IsAttack()
    {
        animator.SetBool("IsAttack", true);

        animator.SetBool("IsBlink", false);
       // animator.SetBool("IsAttack", false);
        animator.SetBool("IsCastSpell", false);
        animator.SetBool("IsDying", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsTaunt", false);
        animator.SetBool("IsWalking", false);
    }

    public void IsCastSpell()
    {
        animator.SetBool("IsCastSpell", true);

        animator.SetBool("IsBlink", false);
        animator.SetBool("IsAttack", false);
       // animator.SetBool("IsCastSpell", false);
        animator.SetBool("IsDying", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsTaunt", false);
        animator.SetBool("IsWalking", false);
    }

    public void IsTaunt()
    {
        animator.SetBool("IsTaunt", true);

        animator.SetBool("IsBlink", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsCastSpell", false);
        animator.SetBool("IsDying", false);
        animator.SetBool("IsHurt", false);
        //animator.SetBool("IsTaunt", false);
        animator.SetBool("IsWalking", false);
    }

    public void IsWalking()
    {
        animator.SetBool("IsWalking", true);

        animator.SetBool("IsBlink", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsCastSpell", false);
        animator.SetBool("IsDying", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsTaunt", false);
        //animator.SetBool("IsWalking", false);
    }

    public void IsHurt()
    {
        animator.SetBool("IsHurt", true);

        animator.SetBool("IsBlink", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsCastSpell", false);
        animator.SetBool("IsDying", false);
        //animator.SetBool("IsHurt", false);
        animator.SetBool("IsTaunt", false);
        animator.SetBool("IsWalking", false);
    }

    public void IsDying()
    {
        animator.SetBool("IsDying", true);

        animator.SetBool("IsBlink", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsCastSpell", false);
        //animator.SetBool("IsDying", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsTaunt", false);
        animator.SetBool("IsWalking", false);
    }

    public void IsIdle()
    {
        animator.SetBool("IsBlink", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsCastSpell", false);
        animator.SetBool("IsDying", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsTaunt", false);
        animator.SetBool("IsWalking", false);
    }
}
