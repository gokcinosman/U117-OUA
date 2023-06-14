using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Karakter hızı
    public float rotationSpeed = 100f; // Dönüş hızı

    private Rigidbody rb;
    private Quaternion targetRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = transform.rotation; // Initialize targetRotation with the initial rotation of the object
    }

    private void Update()
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
    }
}
