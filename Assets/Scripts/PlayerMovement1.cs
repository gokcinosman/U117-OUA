using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float rotationSpeed = 100f;

    [SerializeField]
    private float runSpeedMultiplier = 2f;

    [SerializeField]
    private float jumpForce = 5f;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundDistance = 0.2f;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private float xRotation = 0f;

    private void Update()
    {
        HandleMovement();
        RotateCamera();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Check if the player is running
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Apply movement speed
        float currentSpeed = speed;
        if (isRunning)
            currentSpeed *= runSpeedMultiplier;

        // Calculate movement vector
        Vector3 movement =
            (transform.forward * verticalInput + transform.right * horizontalInput).normalized
            * currentSpeed
            * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
