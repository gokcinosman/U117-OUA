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
            if (localClickPosition.x >= 0)
            {
                targetPosition = transform.position + Vector3.right * moveDistance; // Clicked on the right side, move to the right
            }
            else
            {
                targetPosition = transform.position + Vector3.left * moveDistance; // Clicked on the left side, move to the left
            }

            isMoving = true; // Start moving
        }
    }
}
