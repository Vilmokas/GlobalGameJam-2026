using Unity.Mathematics;
using UnityEngine;

public class DamageRanged : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float damage;

    void OnEnable()
    {
        SpawnProjectile();
    }

    public void SpawnProjectile()
    {
        GameObject attack = Instantiate(projectile, transform.position, quaternion.identity);
        attack.GetComponent<Damage>().damage = damage;
    }
}
