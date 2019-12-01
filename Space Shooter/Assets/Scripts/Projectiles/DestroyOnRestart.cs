using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnRestart : MonoBehaviour
{
    public void DestroyChildOnRestart()
    {
        foreach(Transform child in transform)
        {
            if (child.CompareTag("Enemy"))
            {
                Destroy(child.gameObject);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
