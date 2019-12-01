using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;
    GameObject powerUps;
    [SerializeField] GameObject explosion;

    void Awake()
    {
        currentHealth = startHealth;
        powerUps = GameObject.FindGameObjectWithTag("PowerUps");
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log("inside TakeDamage : "+damage);
        currentHealth -= damage;
        if(currentHealth <= 0){
            Vector3 powerUpsSpawnPosition = gameObject.transform.position;
            if (gameObject.tag.Equals("Enemy"))
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                ++gameManager.scoreCount;
            }
            PlayExplosionAnimation();
            Destroy(gameObject);
            PowerUps script = powerUps.GetComponent<PowerUps>();
            if(script != null){
                script.spawnPowerUps(powerUpsSpawnPosition);
            }
        }
    }

    public void PlayExplosionAnimation()
    {
        GameObject explosionTemp = (GameObject)Instantiate(explosion);
        explosionTemp.transform.position = gameObject.transform.position;
    }
}
