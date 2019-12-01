using System.Collections;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField]float delay = 3.5f;
    public Transform[] spawnPoints;
    public GameObject[] spawnee;
    public ObjectPooler pooler;
    int randomShape = 0, randomPoint = 0;

    // Update is called once per frame
    void OnEnable()
    {
        StartCoroutine(spawnable());
    }


    IEnumerator spawnable()
    {
        while (true)
        {
            //int randomPoint = Random.Range(0, spawnPoints.Length);
            //int randomShape = Random.Range(0, spawnee.Length);

            //Debug.Log("randomShape : "+ randomShape+ "  randomPoint : "+ randomPoint);
            GameObject gObj = pooler.GetObject(spawnee[randomShape].name);
            gObj.transform.position = spawnPoints[randomPoint].position;
            gObj.transform.rotation = spawnPoints[randomPoint].rotation;
            gObj.SetActive(true);
            incremental();

            yield return new WaitForSeconds(delay);
        }

    }

    private void incremental()
    {
        if (randomShape != spawnee.Length-1) {
            ++randomShape;
        } else {
            randomShape = 0;
        }

        if (randomPoint != spawnPoints.Length-1) {
            ++randomPoint;
        } else {
            randomPoint = 0;
        }
    }
}
