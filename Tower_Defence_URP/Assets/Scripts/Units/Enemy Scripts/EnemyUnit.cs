
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyUnit : AUnit
{
    [SerializeField] protected float speed;
    [SerializeField] protected int moneyOnDeath;
    [SerializeField] protected int livesOnEscape;
    [SerializeField] protected string enemyTag;
    [SerializeField] protected EnemyAnimation enemyAnimation;
    [SerializeField] protected float deathAnimation = 1;
    [SerializeField] protected double blinkProbablity = 0.01;

    protected Rigidbody2D rb;
    private GameManager gameManager;
    private MapGrid mapGrid;
    private int pathNum;
    private int positionNum;

    public int LivesOnEscape { get => livesOnEscape; private set => livesOnEscape = value; }
    public int MoneyOnDeath { get => moneyOnDeath; private set => moneyOnDeath = value; }
    public float Speed { get => speed; set => speed = value; }
    public bool IsDying { get; protected set; }

    protected override void Start()
    {
        base.Start();
        gameObject.tag = enemyTag;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        IsDying = false;

        // Determine path number
        mapGrid = FindObjectOfType<MapGrid>();
        pathNum = mapGrid.AssignPathNumber();
        Path path = mapGrid.GetPath(pathNum);
        Vector2Int startPos = path[0];
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(startPos.x, startPos.y);
        positionNum = 0;

        audioManager.PlaySound(AudioManager.Sound.EnemySpawn);
    }

    protected override void Update()
    {
        if (!IsDying)
        {
            Vector2 force = WalkAlongPath();
            // Vector2 force = DirectMoveToExit();

            rb.velocity = force;
            // gameObject.GetComponent<Rigidbody2D>().AddForce(force);

            // Check if at exit
            CheckExit();
        }

        //
        float random = Random.Range(0.0f, 1.0f);
        
        if (random < blinkProbablity) {
            float randomBlink = Random.Range(0.0f, 1.0f);
            if (randomBlink < 0.5f)
            {
                //print("Random Blink");
                enemyAnimation.IsBlink();
            }
            else
            {
                // print("Random Taunt");
                enemyAnimation.IsTaunt();
            }
        }
        else
        {
            
        }
        
    }

    private void CheckExit()
    {
        Path path = mapGrid.GetPath(pathNum);
        if (path.Count - 1 <= positionNum)
        {
            gameManager.Escape(this);
        }
       
        /*
        Path path = mapGrid.GetPath(pathNum);
        Vector2Int endPosition = path.GetEndPosition();

        if (Vector2.Distance(GetPosition(), endPosition) <= mapGrid.EndSensitivity)
        {
            gameManager.Escape(this);
        }
        */
    }

    public override void Attack()
    {
        enemyAnimation.IsAttack();
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        IsDying = true;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        gameManager.Money += MoneyOnDeath;
        enemyAnimation.IsDying();
        audioManager.PlaySound(AudioManager.Sound.EnemyDeath);
        StartCoroutine(EnemyDeath());
    }

    public void Escape()
    {
        gameManager.Money += MoneyOnDeath;
        audioManager.PlaySound(AudioManager.Sound.EnemyExit);
        Destroy(gameObject);
    }

    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(enemyAnimation.getAnimationTime()*deathAnimation);

        Destroy(gameObject);
    }

    public override bool TakeDamage(int damage)
    {
        bool doesTakeDamage = base.TakeDamage(damage);
        if (doesTakeDamage)
        {
            enemyAnimation.IsHurt();
            enemyAnimation.BasicDamage();
        }
        return doesTakeDamage;
    }

    public Vector2 DirectMoveToExit()
    {
        
        Vector2 pos = gameObject.GetComponent<Rigidbody2D>().position;
        Vector2 targetPos = mapGrid.GetPath(pathNum).GetEndPosition();
        Vector2 direction = targetPos - pos;
        direction.Normalize();
        return direction * Speed;
        
    }

    public Vector2 WalkAlongPath()
    {
       
        Vector2 pos = GetPosition();
        Path path = mapGrid.GetPath(pathNum);
        Vector2Int targetPos = path.CalculateNextPosition(pos, positionNum);
        if (!targetPos.Equals(path.GetNextPosition(positionNum)))
        {
            positionNum = path.GetPositionNumber(targetPos);
        }
        Vector2 direction = targetPos - pos;
        direction.Normalize();
        return direction * Speed;
        
    }

    public Vector2 GetPosition()
    {
        return rb.position;
    }
}
