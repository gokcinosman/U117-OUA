using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player character or the key item
        if (other.CompareTag("Player") || other.CompareTag("Grabbable"))
        {
            // Destroy the door object
            Destroy(gameObject);
        }
    }
}

