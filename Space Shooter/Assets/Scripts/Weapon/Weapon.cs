using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour,IWeapon
{
  private int projectileCount;
  public int ProjectileCount { get => projectileCount;}
  protected GameObject projectile;
  protected float fireRate;

  [SerializeField] private WeaponObject weapon;

  void Awake()
  {
      projectileCount = weapon.projectileCount;
      projectile = weapon.projectiles;
      fireRate = weapon.fireRate;
  }

  public abstract void Shoot();

}
