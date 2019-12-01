using System;

public interface IWeapon : IShoot
{
    int ProjectileCount { get; } // For pooling purpose

}
