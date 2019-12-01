using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void OnBecameInvisible(){
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void Destroy()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
