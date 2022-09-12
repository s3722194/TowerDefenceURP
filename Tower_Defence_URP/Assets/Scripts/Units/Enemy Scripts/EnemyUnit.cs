using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyUnit : AUnit
{
    [SerializeField] private int moneyOnDeath;
    [SerializeField] private int livesOnEscape;
    [SerializeField] private string enemyTag;

    public int LivesOnEscape { get => livesOnEscape; private set => livesOnEscape = value; }
    public int MoneyOnDeath { get => moneyOnDeath; private set => moneyOnDeath = value; }

    private GameManager gameManager;
    private LevelManager levelManager;
    private MapGrid mapGrid;
    private int pathNum;
    private int positionNum;

    protected override void Start()
    {
        base.Start();
        gameObject.tag = enemyTag;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        // Determine path number
        mapGrid = FindObjectOfType<MapGrid>();
        pathNum = mapGrid.AssignPathNumber();
        Path path = mapGrid.GetPath(pathNum);
        Vector2Int startPos = path[0];
        GetComponent<Rigidbody2D>().position = new Vector3(startPos.x, startPos.y);
        positionNum = 0;
    }

    protected override void Update()
    {
        Vector2 force = WalkAlongPath();
        // Vector2 force = DirectMoveToExit();

        gameObject.GetComponent<Rigidbody2D>().AddForce(force);

        // Check if at exit
        CheckExit();
    }

    private void CheckExit()
    {
        Path path = mapGrid.GetPath(pathNum);
        Vector2Int endPosition = path.GetEndPosition();

        if (Vector2.Distance(GetPosition(), endPosition) <= mapGrid.EndSensitivity)
        {
            gameManager.Escape(this);
        }
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        gameManager.Money += MoneyOnDeath;
        Destroy(gameObject);
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
        if (!targetPos.Equals(path.GetNextPosition(positionNum))) {
            positionNum = path.GetPositionNumber(targetPos);
        }
        Vector2 direction = targetPos - pos;
        direction.Normalize();
        return direction * Speed;
    }

    public Vector2 GetPosition()
    {
        return gameObject.GetComponent<Rigidbody2D>().position;
    }
}
