using UnityEngine;

public class MouseLock : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
