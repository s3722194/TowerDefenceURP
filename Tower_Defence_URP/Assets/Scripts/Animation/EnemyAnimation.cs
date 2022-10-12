using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Material basicMaterial;
    [SerializeField] private Material orbMaterial;
    [SerializeField] private Material fireMaterial;
    [SerializeField] private Material blackHoleMaterial;
    [SerializeField] private Material fogMaterial;
    [SerializeField] private Material shockMaterial;
    [SerializeField] private Material toxicMaterial;
    [SerializeField] private Material lazerMaterial;
    [SerializeField] private Material deathRayMaterial;

    [SerializeField] private bool basicDamage;
    [SerializeField] private bool toxicDamage;
    [SerializeField] private bool fogDamage;
    [SerializeField] private bool blackHoleDamage;
    [SerializeField] private bool fireDamage;
    [SerializeField] private bool deathRayDamage;
    [SerializeField] private bool lazerDamage;
    [SerializeField] private bool orbDamage;
    [SerializeField] private bool shockDamage;

    [SerializeField] private bool isBlink;
    [SerializeField] private bool isAttack;
    [SerializeField] private bool isCastSpell;
    [SerializeField] private bool isDying;
    [SerializeField] private bool isDeath;
    [SerializeField] private bool isHurt;
    [SerializeField] private bool isTaunt;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isIdle;

    [SerializeField] private float animationTime = 1;

    private Animator animator;

    private SpriteRenderer sr;
    private Material enemyMaterial;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        enemyMaterial = sr.material;
    }

    // Update is called once per frame
    void Update()
    {

        //TestAnimation();
        //TestDamage();


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

    private void TestDamage()
    {
        if (orbDamage)
        {
            OrbDamage();
        } 
        else if (fireDamage)
        {
            FireDamage();
        } else if (toxicDamage)
        {
            ToxicDamage();
        } else if (shockDamage)
        {
            ShockDamage();
        } else if (deathRayDamage)
        {
            DeathRayDamage();
        } else if (lazerDamage)
        {
            LazerDamage();
        } else if (basicDamage)
        {
            BasicDamage();
        } else
        {
            NoDamage();
        }
    }

    IEnumerator ResetMaterial()
    {
        yield return new WaitForSeconds(animationTime);
        NoDamage();
       

    }

    IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(animationTime);
        
        IsIdle();

    }



    public void NoDamage()
    {
        sr.material = enemyMaterial; 
    }

    public void OrbDamage()
    {
        if(orbMaterial != null)
        {
            sr.material = orbMaterial;
        }
        else
        {
            sr.material = basicMaterial;
        }

        StartCoroutine(ResetMaterial());
    }

    public void BasicDamage()
    {
        
        sr.material = basicMaterial;

        StartCoroutine(ResetMaterial());
    }

    public void LazerDamage()
    {
        if (lazerMaterial != null)
        {
            sr.material = lazerMaterial;
        }
        else
        {
            sr.material = basicMaterial;
        }
        StartCoroutine(ResetMaterial());
    }

    public void BlackHoleDamage()
    {
        if (blackHoleMaterial != null)
        {
            sr.material = blackHoleMaterial;
        }
        else
        {
            sr.material = basicMaterial;
        }
        StartCoroutine(ResetMaterial());
    }

    public void DeathRayDamage()
    {
        if (deathRayMaterial != null)
        {
            sr.material = deathRayMaterial;
        }
        else
        {
            sr.material = basicMaterial;
        }
        StartCoroutine(ResetMaterial());
    }

    public void FogDamage()
    {
        if (fogMaterial != null)
        {
            sr.material = fogMaterial;
        }
        else
        {
            sr.material = basicMaterial;
        }
        StartCoroutine(ResetMaterial());
    }

    public void FireDamage()
    {
        if (fireMaterial != null)
        {
            sr.material = fireMaterial;
        }
        else
        {
            sr.material = basicMaterial;
        }
        StartCoroutine(ResetMaterial());
    }

    public void ToxicDamage()
    {
        if (toxicMaterial != null)
        {
            sr.material = toxicMaterial;
        }
        else
        {
            sr.material = basicMaterial;
        }
        StartCoroutine(ResetMaterial());
    }

    public void ShockDamage()
    {
        if (shockMaterial != null)
        {
            sr.material = orbMaterial;
        }
        else
        {
            sr.material = basicMaterial;
        }
        StartCoroutine(ResetMaterial());
    }

    public float getAnimationTime()
    {
        return animationTime;
    }


    public void IsBlink()
    {
        if(!animator.GetBool("IsHurt") && 
            !animator.GetBool("IsDying") && 
            !animator.GetBool("IsTaunt") &&
            !animator.GetBool("IsBlink"))
        {
            animator.SetBool("IsBlink", true);

            //animator.SetBool("IsBlink", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsCastSpell", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsHurt", false);
            animator.SetBool("IsTaunt", false);
            animator.SetBool("IsWalking", false);

            StartCoroutine(ResetAnimation());
        }
        
    }

    
    public void IsAttack()
    {
        if (!animator.GetBool("IsAttack"))
        {
            animator.SetBool("IsAttack", true);

            animator.SetBool("IsBlink", false);
            // animator.SetBool("IsAttack", false);
            animator.SetBool("IsCastSpell", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsHurt", false);
            animator.SetBool("IsTaunt", false);
            animator.SetBool("IsWalking", false);
            StartCoroutine(ResetAnimation());
        }
            
    }

    public void IsCastSpell()
    {
        if (!animator.GetBool("IsCastSpell"))
        {
            animator.SetBool("IsCastSpell", true);

            animator.SetBool("IsBlink", false);
            animator.SetBool("IsAttack", false);
            // animator.SetBool("IsCastSpell", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsHurt", false);
            animator.SetBool("IsTaunt", false);
            animator.SetBool("IsWalking", false);
            StartCoroutine(ResetAnimation());
        }
       
    }

    public void IsTaunt()
    {
        if(!animator.GetBool("IsHurt") && 
            !animator.GetBool("IsDying") && 
            !animator.GetBool("IsBlink") && 
            !animator.GetBool("IsTaunt"))
        {
            animator.SetBool("IsTaunt", true);

            animator.SetBool("IsBlink", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsCastSpell", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsHurt", false);
            //animator.SetBool("IsTaunt", false);
            animator.SetBool("IsWalking", false);
            StartCoroutine(ResetAnimation());
        }
            
       
    }

    public void IsWalking()
    {
        if (!animator.GetBool("IsWalking")) 
        {
            animator.SetBool("IsWalking", true);

            animator.SetBool("IsBlink", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsCastSpell", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsHurt", false);
            animator.SetBool("IsTaunt", false);
            //animator.SetBool("IsWalking", false);
            StartCoroutine(ResetAnimation());
        }
        
    }

    public void IsHurt()
    {
        if (!animator.GetBool("IsDying") && !animator.GetBool("IsHurt"))
        {
            animator.SetBool("IsHurt", true);

            animator.SetBool("IsBlink", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsCastSpell", false);
            animator.SetBool("IsDying", false);
            //animator.SetBool("IsHurt", false);
            animator.SetBool("IsTaunt", false);
            animator.SetBool("IsWalking", false);
            StartCoroutine(ResetAnimation());
        }
       
    }

    public void IsDying()
    {
        if (!animator.GetBool("IsDying"))
        {
            animator.SetBool("IsDying", true);

            animator.SetBool("IsBlink", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsCastSpell", false);
            //animator.SetBool("IsDying", false);
            animator.SetBool("IsHurt", false);
            animator.SetBool("IsTaunt", false);
            animator.SetBool("IsWalking", false);
            StartCoroutine(ResetAnimation());
        }
      
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
       // StartCoroutine(ResetAnimation());
    }
}
