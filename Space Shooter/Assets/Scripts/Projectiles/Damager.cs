using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
  public int damageAmount;

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Enemy") && gameObject.tag.Equals("PlayerBullet"))
    {
      Health opponentshealth = collider.GetComponent<Health>();
      if (opponentshealth != null)
      {
        opponentshealth.TakeDamage(damageAmount);
      }
      gameObject.SetActive(false);
    }
    else if(collider.CompareTag("Player") && gameObject.tag.Equals("EnemyBullet"))
    {
        //Debug.Log("inside else if");
        Health opponentshealth = collider.GetComponent<Health>();
        if (opponentshealth != null)
        {
          opponentshealth.TakeDamage(damageAmount);
        }
        gameObject.SetActive(false);
    }
  }
}
