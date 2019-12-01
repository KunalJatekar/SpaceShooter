using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsMovement : MonoBehaviour
{
    float moveSpeed;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.6f;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, -2f, 0) * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // PlayerShoot ps = other.GetComponent<PlayerShoot>();
            // if(ps != null)
            // {
            //     ps.EquipWeapoon(weapon);
            //     Debug.Log("insie OnTriggerEnter2d");
            // }
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            if(sr != null && sr.sortingLayerName == "PowerUpPillRed"){
                audioSource.Play();
                PlayerPowerUps playerPowerUps = other.GetComponent<PlayerPowerUps>();
                playerPowerUps.HealthPowerUp();
            }
            if(sr != null && sr.sortingLayerName == "PowerUpRedBolt"){
                audioSource.Play();
                Debug.Log("insie OnTriggerEnter2d PowerUpRedBolt");
            }
            if(sr != null && sr.sortingLayerName == "PowerUpRedShield"){
                audioSource.Play();
                Debug.Log("insie OnTriggerEnter2d PowerUpRedShield");
            }
            if(sr != null && sr.sortingLayerName == "PowerUpRedStar"){
                audioSource.Play();
                Debug.Log("insie OnTriggerEnter2d PowerUpRedStar");
            }

            gameObject.SetActive(false);
        }
    }
}
