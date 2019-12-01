using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    AudioSource audioSource;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.7f;
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, -2f, 0) * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            gameManager.coinCount++;
            gameObject.SetActive(false);
        }
    }
}
