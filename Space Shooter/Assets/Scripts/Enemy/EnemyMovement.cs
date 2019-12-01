using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float downSpeed;
    GameManager manager;

    void Start(){
        moveSpeed = 0.5f;
        downSpeed = 2f;
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<SpriteRenderer>().sortingLayerName.Equals("Aestroid"))
        {
            downSpeed = 1f;
        }
        transform.position += new Vector3(0, -downSpeed, 0) * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("Player")){
            Health health = other.gameObject.GetComponent<Health>();
            health.PlayExplosionAnimation();
            other.gameObject.SetActive(false);
            Invoke("callEndMenu", 1.0f);
        }
    }

    void callEndMenu()
    {
        Time.timeScale = 0;
        manager.ShowEndMenu();
    }
}
