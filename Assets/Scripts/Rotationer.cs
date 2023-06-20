using UnityEngine;

public class Rotationer : MonoBehaviour
{
    [SerializeField]
    private Transform objectToRotate;

    [SerializeField]
    private GameObject leftArrow;

    [SerializeField]
    private GameObject rightArrow;

    // Rotation variables
    private bool isRotating;
    private float rotationDirection;

    // Initial and target rotations
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    // Rotation settings (degrees)
    [Range(0, 360)]
    public float rotationAngle = 90f;

    // Rotation speed (degrees per second)
    public float rotationSpeed = 90f;

    void Start()
    {
        initialRotation = objectToRotate.rotation;
    }

    void Update()
    {
        if (!isRotating && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == leftArrow)
                {
                    RotateObject(1);
                }
                else if (hit.collider.gameObject == rightArrow)
                {
                    RotateObject(-1);
                }
            }
        }

        if (isRotating)
        {
            float step = rotationSpeed * Time.deltaTime;
            objectToRotate.rotation = Quaternion.RotateTowards(
                objectToRotate.rotation,
                targetRotation,
                step
            );

            if (Quaternion.Angle(objectToRotate.rotation, targetRotation) <= Mathf.Epsilon)
            {
                objectToRotate.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    // Rotates the object by rotationDirection * rotationAngle degrees
    void RotateObject(float direction)
    {
        isRotating = true;

        targetRotation = objectToRotate.rotation * Quaternion.Euler(0f, 90 * direction, 0f);
    }
}
