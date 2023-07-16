using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickDestroy : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Destroy the door object
        Destroy(gameObject);
    }
}

