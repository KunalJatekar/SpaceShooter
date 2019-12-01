using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    [SerializeField] float moveTime;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, -moveTime * Time.deltaTime, 0f);
    }
}
