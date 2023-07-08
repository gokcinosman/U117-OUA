using UnityEngine;

public class Rotationer : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Transform objectToRotate;

    [SerializeField]
    private GameObject leftArrow;

    [SerializeField]
    private GameObject rightArrow;

    private bool isRotating;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    [Range(0, 360)]
    public float rotationAngle = 90f;
    public float rotationSpeed = 90f;

    private void Start()
    {
        initialRotation = objectToRotate.rotation;
    }

    private void Update()
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
                animator.SetBool("isInteract", false);
            }
        }
    }

    private void RotateObject(float direction)
    {
        isRotating = true;
        animator.SetBool("isInteract", true);

        targetRotation =
            objectToRotate.rotation * Quaternion.Euler(0f, 0, rotationAngle * direction);
    }
}
