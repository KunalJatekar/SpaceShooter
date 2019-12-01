using UnityEngine;

[CreateAssetMenu(menuName = "Weapon",fileName = "Weapon")]
public class WeaponObject : ScriptableObject
{
    public int projectileCount;
    public GameObject projectiles;
    public float fireRate;
}
