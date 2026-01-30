using UnityEngine;
using UnityEngine.InputSystem;
using static Masks;

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
    InputAction interact;
    Rigidbody2D body;
    int jumpCount;
    [SerializeField]
    int maxJumpCount;

    [SerializeField]
    TYPES currentType;
    [SerializeField]
    GameObject interactButton;

    [SerializeField]
    GameObject[] sprites;

    void Start()
    {
        currentType = TYPES.basic;
        body = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    void OnEnable()
    {
        move = actions.FindAction("Move");
        jump = actions.FindAction("Jump");
        interact = actions.FindAction("Interact");

        move.Enable();
        jump.Enable();
        interact.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        jump.Disable();
        interact.Disable();
    }

    void Update()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();

        if (jump.WasPressedThisFrame() && jumpCount > 0)
        {
            body.AddForceY(jumpForce);
            jumpCount--;
        }

        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = maxJumpCount;


        if (collision.gameObject.TryGetComponent(out Mask mask))
        {
            interactButton.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Mask mask))
        {
            interactButton.SetActive(false);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Mask mask) && interact.WasPressedThisFrame())
        {
            ChangeMask(mask.type);
            collision.gameObject.SetActive(false);
            interactButton.SetActive(false);
        }
    }

    void ChangeMask(TYPES newMask)
    {
        if (currentType != newMask)
        {
            currentType = newMask;
            switch (currentType)
            {
                case TYPES.basic:
                    sprites[0].SetActive(true);
                    sprites[1].SetActive(false);
                    sprites[2].SetActive(false);
                    break;
                case TYPES.heavy:
                    sprites[0].SetActive(false);
                    sprites[1].SetActive(true);
                    sprites[2].SetActive(false);
                    break;
                case TYPES.ranged:
                    sprites[0].SetActive(false);
                    sprites[1].SetActive(false);
                    sprites[2].SetActive(true);
                    break;
                default:
                    sprites[0].SetActive(true);
                    sprites[1].SetActive(false);
                    sprites[2].SetActive(false);
                    break;
            }
        }
    }
}
