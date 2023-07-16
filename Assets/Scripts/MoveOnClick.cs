using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    public float moveDistance = 1f; // Distance to move
    public float moveSpeed = 1f;    // Movement speed

    private bool isMoving = false;  // Flag indicating if the object is currently moving
    private Vector3 targetPosition; // Target position for movement

    private void Start()
    {
        // Set the initial target position to the object's current position
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the object has reached the target position
            if (transform.position == targetPosition)
            {
                isMoving = false; // Stop moving
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            // Get the click position in world space
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Determine the click position relative to the object's transform
            Vector3 localClickPosition = transform.InverseTransformPoint(clickPosition);

            // Calculate the new target position based on the click position
            Vector3 movementDirection = Vector3.zero;

            if (Mathf.Abs(localClickPosition.x) >= Mathf.Abs(localClickPosition.z))
            {
                // Clicked on the left or right side
                movementDirection = localClickPosition.x >= 0 ? Vector3.right : Vector3.left;
            }
            else
            {
                // Clicked on the forward or backward side
                movementDirection = localClickPosition.z >= 0 ? Vector3.forward : Vector3.back;
            }

            targetPosition = transform.position + movementDirection * moveDistance;
            isMoving = true; // Start moving
        }
    }
}
