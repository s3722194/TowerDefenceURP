using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] private string waveName;
    [SerializeField] private Spawn[] spawnList;
    [SerializeField] private int endWaveBonus;

    public int EndWaveBonus { get => endWaveBonus; private set => endWaveBonus = value; }
    public Spawn[] SpawnList { get => spawnList; private set => spawnList = value; }
    public int Length { get => spawnList.Length; }

    [System.Serializable]
    public class Spawn
    {
        public EnemyUnit enemy;
        public float delayToThis;
    }
}
