using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    InputActionAsset actions;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;

    InputAction move;
    InputAction jump;
    Rigidbody2D body;
    int jumpCount;
    [SerializeField]
    int maxJumpCount;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    void OnEnable()
    {
        move = actions.FindAction("Move");
        jump = actions.FindAction("Jump");

        move.Enable();
        jump.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    void Update()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();

        if (jump.WasPressedThisFrame() && jumpCount > 0)
        {
            body.AddForceY(jumpForce);
            jumpCount--;
        }

        transform.Translate(
            new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.deltaTime
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = maxJumpCount;
    }
}
