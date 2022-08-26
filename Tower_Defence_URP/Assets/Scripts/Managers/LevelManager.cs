using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int money;
    private int lives;
    private float time;

    [SerializeField] private int delayStart;

    public int Money { get => money; set => money = value; }
    public int Lives { get => lives; set => lives = value; }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.fixedDeltaTime;
        if (time > delayStart)
        {
            // Start sending waves
        }
    }

    public void Escape(EnemyUnit unit)
    {
        Lives -= unit.LivesOnEscape;
        Money += unit.MoneyOnDeath;
        if (Lives <= 0)
        {
            // TODO: End Level.
        }
    }
}
