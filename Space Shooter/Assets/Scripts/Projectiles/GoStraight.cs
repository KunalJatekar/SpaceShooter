using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoStraight : MonoBehaviour
{
    [Header("Projectiles shoot speed")]
    [SerializeField] private float speed;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(gameObject.tag.Equals("EnemyBullet"))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        else if(gameObject.tag.Equals("PlayerBullet"))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
}
