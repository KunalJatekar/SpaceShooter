using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject weaponAary;
    Transform weaponSocket;
    Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weaponSocket = transform.GetChild(0);
        EquipWeapoon(weaponAary);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        weapon.Shoot();
    }

    public void EquipWeapoon(GameObject _weapon)
    {
        if(weapon != null){
            Destroy(weapon.gameObject);
        }
        GameObject weAary = Instantiate(_weapon, weaponSocket.position, Quaternion.identity, weaponSocket);
        weapon = weAary.GetComponent<Weapon>();
    }
}
