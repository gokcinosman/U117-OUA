using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField]
    private Transform holdArea;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;

    [Header("Physics Settings")]
    [SerializeField]
    private float pickupRange = 3f;

    [SerializeField]
    private float pickupForce = 5000f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            heldObjectRb.AddForce(moveDirection * pickupForce * Time.deltaTime);
        }
        else
        {
            heldObjectRb.velocity = Vector3.zero;
        }
    }

    private void PickupObject(GameObject pickObject)
    {
        Rigidbody pickObjectRb = pickObject.GetComponent<Rigidbody>();
        if (pickObjectRb != null)
        {
            heldObjectRb = pickObjectRb;
            heldObjectRb.useGravity = false;
            heldObjectRb.drag = 10f;
            heldObjectRb.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjectRb.transform.parent = holdArea;
            heldObject = pickObject;
        }
    }

    private void DropObject()
    {
        if (heldObjectRb != null)
        {
            heldObjectRb.useGravity = true;
            heldObjectRb.drag = 1f;
            heldObjectRb.constraints = RigidbodyConstraints.None;
            heldObject.transform.parent = null;
            heldObjectRb = null;
            heldObject = null;
        }
    }
}
