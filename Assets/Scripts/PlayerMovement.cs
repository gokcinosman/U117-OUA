using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Karakter hızı
    public float rotationSpeed = 100f; // Dönüş hızı
    public float jumpForce = 5f; // Zıplama kuvveti
    public Transform groundCheck; // Ground check için kullanılan boş nesne
    public float groundDistance = 0.2f; // Ground check mesafesi
    public LayerMask groundLayer; // Zeminin layer'ı

    private Rigidbody rb;
    private Quaternion targetRotation;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = transform.rotation; // İlk rotasyonu hedef rotasyon olarak ayarla
    }

    private void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
            targetRotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up); // Sağa dönme

        if (horizontalInput < 0)
            targetRotation *= Quaternion.AngleAxis(-rotationSpeed * Time.deltaTime, Vector3.up); // Sola dönme

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.forward * verticalInput * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

        // Ground check'i yap ve isGrounded değerini güncelle
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
