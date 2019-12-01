using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazeLayer : MonoBehaviour
{
    public float ParallaxFactor = 0f;

    Transform theCamera;
    Renderer rendere;

    Vector3 theStartPosition;

    void Start()
    {
        theCamera = Camera.main.transform;
        theStartPosition = transform.position;

        rendere = GetComponent<Renderer>();
    }

    void Update()
    {
        rendere.material.mainTextureOffset = new Vector2(0f, Time.time * ParallaxFactor);
    }
}
