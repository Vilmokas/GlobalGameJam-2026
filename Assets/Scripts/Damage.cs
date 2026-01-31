using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }
    }
}
