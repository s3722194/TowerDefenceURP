using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject selectedTower;

    private int lives;
    private int money;
    public int Money {  get => money; set => money =value; }
    
    public int Lives { get => lives; set => lives = value; }
    // Start is called before the first frame update
    void Start()
    {
        // probs want to inistialise these values
        // idk what they are so i wont touch them
        Lives = 100;
        Money = 100000;
        selectedTower = null;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void SpendMoney(int cost)
    {
        Money -= cost;
    }

    public void SetSelectedTower(GameObject _selectedTower)
    {
        selectedTower = _selectedTower;
    }

    public void ResetTower()
    {
        selectedTower = null;
    }

    public GameObject GetSelectedTower()
    {
        return selectedTower;
    }
}
