using UnityEngine;

public class MouseLock : MonoBehaviour
{
    private bool isMouseLocked = true; // Fare kilitlenmiş olarak başlasın

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Fare tıklandığında
        {
            isMouseLocked = !isMouseLocked; // Fare kilidini tersine çevir

            if (isMouseLocked)
            {
                LockMouse(); // Fareyi kitle
            }
            else
            {
                UnlockMouse(); // Fare kilidini kaldır
            }
        }
    }

    private void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked; // Fareyi kitle
        Cursor.visible = false; // Fareyi görünmez yap
    }

    private void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None; // Fare kilidini kaldır
        Cursor.visible = true; // Fareyi görünür yap
    }
}
