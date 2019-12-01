using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] GameObject weapon;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerShoot ps = other.GetComponent<PlayerShoot>();
            if(ps != null)
            {
                ps.EquipWeapoon(weapon);
                Debug.Log("insie OnTriggerEnter2d");
            }

            gameObject.SetActive(false);
        }
    }
}
