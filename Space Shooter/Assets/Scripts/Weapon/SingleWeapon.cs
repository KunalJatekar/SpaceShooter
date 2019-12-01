using UnityEngine;
using System;


public class SingleWeapon : Weapon
{
    Transform socket; // projectiles instantiation point
    private float nextFireTime = 0.0f;


    void Start()
    {
        socket = transform.GetChild(0);
    }

    public override void Shoot()
    {
        if (Time.time - fireRate > nextFireTime)
        {
            nextFireTime = Time.time - Time.deltaTime;
        }

        while (nextFireTime < Time.time)
        {
            Instantiate(projectile, socket.position, Quaternion.identity);
            nextFireTime += fireRate;
        }
    }
}
