using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName = "Enemy")]
public class EnemyObject : ScriptableObject
{
    public int enemyCount;
    public GameObject[] projectiles;
}
