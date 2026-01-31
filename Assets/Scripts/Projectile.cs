using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }
}
