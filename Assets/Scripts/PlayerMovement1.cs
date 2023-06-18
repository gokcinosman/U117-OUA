using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // Karakter hızı

    [SerializeField]
    private float rotationSpeed = 100f; // Dönüş hızı

    [SerializeField]
    private float jumpForce = 5f; // Zıplama kuvveti

    [SerializeField]
    private Transform groundCheck; // Ground check için kullanılan boş nesne

    [SerializeField]
    private float groundDistance = 0.2f; // Ground check mesafesi

    [SerializeField]
    private LayerMask groundLayer; // Zeminin layer'ı

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

        // Karakterin hareketini kontrol et
        Vector3 movement =
            (transform.forward * verticalInput + transform.right * horizontalInput)
            * speed
            * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

        // Ground check'i yap ve isGrounded değerini güncelle
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

        // Yatay eksende oyuncuyu (karakteri) döndürme işlemi
        transform.Rotate(Vector3.up, mouseX);

        // Dikey eksendeki kamera rotasyonunu güncelleme işlemi.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
