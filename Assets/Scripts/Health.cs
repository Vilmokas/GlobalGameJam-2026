using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float health = 1;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
