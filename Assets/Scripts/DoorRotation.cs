using UnityEngine;

public class DoorRotation : MonoBehaviour
{
    private const string LeftDoorName = "LeftDoor";
    private const string RightDoorName = "RightDoor";
    private const float LeftRotationAngle = 90f;
    private const float RightRotationAngle = -90f;
    private const float RotationSpeed = 200f;

    private bool isRotating = false;
    private Quaternion targetRotation;

    private void OnMouseDown()
    {
        if (!isRotating)
        {
            string objectName = gameObject.name;
            if (objectName == LeftDoorName)
            {
                targetRotation = Quaternion.Euler(0f, LeftRotationAngle, 0f);
            }
            else if (objectName == RightDoorName)
            {
                targetRotation = Quaternion.Euler(0f, RightRotationAngle, 0f);
            }

            StartCoroutine(RotateDoorSmoothly());
        }
    }

    private System.Collections.IEnumerator RotateDoorSmoothly()
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        float distance = Quaternion.Angle(startRotation, targetRotation);

        while (distance > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                RotationSpeed * Time.deltaTime
            );
            distance = Quaternion.Angle(transform.rotation, targetRotation);
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }
}
