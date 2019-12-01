using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    public int enemySpawnCount;
    public int EnemySpawnCount => enemySpawnCount; 
}
