using UnityEngine;

public class Rotationer : MonoBehaviour
{
    [SerializeField]
    private Transform objectToRotate;

    [SerializeField]
    private GameObject leftArrow;

    [SerializeField]
    private GameObject rightArrow;
    private bool isRotatingLeft;
    private bool isRotatingRight;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == leftArrow)
                {
                    isRotatingLeft = true;
                    isRotatingRight = false;
                }
                else if (hit.collider.gameObject == rightArrow)
                {
                    isRotatingLeft = false;
                    isRotatingRight = true;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotatingLeft = false;
            isRotatingRight = false;
        }

        if (isRotatingLeft)
        {
            RotateObject(1f);
        }
        else if (isRotatingRight)
        {
            RotateObject(-1f);
        }
    }

    private void RotateObject(float direction)
    {
        float rotationSpeed = 1f; // Adjust the rotation speed as desired
        objectToRotate.Rotate(Vector3.up * rotationSpeed * direction);
    }
}
