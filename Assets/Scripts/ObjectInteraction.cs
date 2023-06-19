using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private GameObject grabbedObject; // Tutulan eşya
    private float grabDistance = 2f; // Eşya tutma mesafesi
    private float grabHeight = 0.5f;
    private bool isGrabbing;
    private Rigidbody grabbedObjectRigidbody; // Tutulan nesnenin Rigidbody bileşeni

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isGrabbing)
        {
            // Check if there is a grabbable object within range
            Collider[] colliders = Physics.OverlapSphere(transform.position, grabDistance);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Grabbable"))
                {
                    grabbedObject = collider.gameObject;
                    grabbedObjectRigidbody = grabbedObject.GetComponent<Rigidbody>();
                    grabbedObjectRigidbody.isKinematic = true;
                    grabbedObjectRigidbody.detectCollisions = false;
                    grabbedObject.transform.SetParent(transform);
                    isGrabbing = true;
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && isGrabbing)
        {
            grabbedObject.transform.SetParent(null);
            grabbedObjectRigidbody.isKinematic = false;
            grabbedObjectRigidbody.detectCollisions = true;
            grabbedObject = null;
            grabbedObjectRigidbody = null;
            isGrabbing = false;
        }

        if (isGrabbing)
        {
            UpdateGrabbedObjectPosition();
        }
    }

    private void UpdateGrabbedObjectPosition()
    {
        Vector3 newPosition =
            Camera.main.transform.position
            + Camera.main.transform.forward * grabDistance
            + (Camera.main.transform.up * grabHeight);
        grabbedObject.transform.position = newPosition;
    }
}
