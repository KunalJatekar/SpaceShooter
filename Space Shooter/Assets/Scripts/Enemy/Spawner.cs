using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] whatToSpawn;
    [SerializeField] Transform[] whereToSpawn;
    [SerializeField] float delay;
    [SerializeField] Transform parentGameObject;

    // Start is called before the first frame update
    void OnEnable()
    {
        //delay = 5f;
        StartCoroutine(spawnee());
    }

    IEnumerator spawnee()
    {
        while (true)
        {
            int randomPointToSpawn = Random.Range(0, whereToSpawn.Length);
            int randomObjectToSpawn = Random.Range(0, whatToSpawn.Length);
            Instantiate(whatToSpawn[randomObjectToSpawn], whereToSpawn[randomPointToSpawn].position, Quaternion.identity, parentGameObject);
            yield return new WaitForSeconds(delay);
        }

    }
}
