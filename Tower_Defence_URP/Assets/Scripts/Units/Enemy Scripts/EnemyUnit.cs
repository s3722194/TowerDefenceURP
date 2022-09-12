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
    private Vector2Int[] nextPositions;

    protected override void Start()
    {
        base.Start();
        gameObject.tag = enemyTag;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        // Determine path number
        mapGrid = FindObjectOfType<MapGrid>();
        pathNum = mapGrid.AssignPathNumber();
        Path path = mapGrid.GetPathFromNumber(pathNum);
        Vector2Int startPos = path[0];
        GetComponent<Rigidbody2D>().position = new Vector3(startPos.x, startPos.y);

        nextPositions = new Vector2Int[2];
        nextPositions[0] = path.GetNextPosition(0);
        nextPositions[1] = path.GetNextPosition(1);
    }

    protected override void Update()
    {
        // Vector 2 force = WalkAlongPath();
        Vector2 force = DirectMoveToExit();

        gameObject.GetComponent<Rigidbody2D>().AddForce(force);

        // Check if at exit
        CheckExit();
    }

    private void CheckExit()
    {
        GameObject levelManagerObject = GameObject.Find("LevelManager");
        LevelManager levelManager = levelManagerObject.GetComponent<LevelManager>();

        GameObject tiles = GameObject.Find("SpawnTiles");
        SpawnGrid grid = tiles.GetComponent<SpawnGrid>();

        if (Vector2.Distance(gameObject.GetComponent<Rigidbody2D>().position, GetEndPosition()) <= grid.EndSensitivity)
        {
            gameManager.Escape(this);
        }
        throw new NotImplementedException();
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

    public Vector2 GetStartPosition()
    {
        GameObject tiles = GameObject.Find("SpawnTiles");
        SpawnGrid grid = tiles.GetComponent<SpawnGrid>();
        return grid.Opening;
    }

    public Vector2 DirectMoveToExit()
    {
        Vector2 pos = gameObject.GetComponent<Rigidbody2D>().position;
        Vector2 targetPos = mapGrid.GetPathFromNumber(pathNum).GetEndPosition();
        Vector2 direction = targetPos - pos;
        direction.Normalize();
        return direction * Speed;
    }

    public Vector2 WalkAlongPath()
    {
        Vector2 pos = GetPosition();
        Vector2 targetPos = mapGrid.GetPathFromNumber(pathNum).get;
        Vector
    }

    public Vector2 GetPosition()
    {
        return gameObject.GetComponent<Rigidbody2D>().position;
    }
}
