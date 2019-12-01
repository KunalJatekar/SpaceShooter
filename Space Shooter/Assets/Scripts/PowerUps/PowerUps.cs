using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] GameObject[] whatToSpawn;
    Transform powerUpsSpawnPoints;

    void Start(){
        powerUpsSpawnPoints = transform.GetChild(0);
    }

    public void spawnPowerUps(Vector3 whereToSpawn)
    {
        int randomPoint = Random.Range(0, whatToSpawn.Length);
        Instantiate(whatToSpawn[randomPoint], whereToSpawn, Quaternion.identity, powerUpsSpawnPoints.transform);
    }

}
