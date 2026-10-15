using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;

    private Vector2 moveInput;
    private Vector3 movement;

    private Rigidbody playerRb;
    private InputSystem_Actions controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterMovement();
    }

    private void CharacterMovement()
    {
        // Reads movement values from the Input Actions
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        // Creating a new vector movement that will get values on the x and z axis
        movement = new Vector3(moveInput.x, 0f, moveInput.y);
        movement = Vector3.ClampMagnitude(movement, 1f);

        // Defines player's velocity
        Vector3 velocity = playerRb.linearVelocity;

        // Multiply player's velocity by the input given by user (current velocity = 1 -moveInput- * 15 -moveSpeed-)
        velocity.x = movement.x * moveSpeed;
        velocity.z = movement.z * moveSpeed;

        // Apply the a new calculated velocity to the player's rigidbody
        playerRb.linearVelocity = velocity;
    }
}
