using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShoot : MonoBehaviour, IShoot
{

  [SerializeField] GameObject weaponAary;
  Transform weaponSocket;
  Transform multiWeaponSocket;
  Weapon weapon;

  // Start is called before the first frame update
  void Start()
  {
    weaponSocket = transform.GetChild(0);
    multiWeaponSocket = transform.GetChild(1);
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

  public void EquipMultipleWeapoon(GameObject _weapon)
  {
    if(weapon != null){
      Destroy(weapon.gameObject);
    }
    GameObject weAary = Instantiate(_weapon, multiWeaponSocket.position, Quaternion.identity, multiWeaponSocket);
    weapon = weAary.GetComponent<Weapon>();
  }

}
