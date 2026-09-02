using UnityEngine;
using UnityEngine.InputSystem;

//DONE BY GEMINI< DIDNT WANT TO WASTE MY TIME

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private float sensitivity = 0.5f; // Helps keep movement smooth
    
    private InputAction OnLook;
    
    // Track rotation outside of the Update loop
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Awake()
    {
        OnLook = input.actions["Look"];
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        var lookDirection = OnLook.ReadValue<Vector2>();

        // 1. Accumulate the rotation
        yRotation += lookDirection.x * sensitivity;
        xRotation -= lookDirection.y * sensitivity; // Subtract to avoid inverted look

        // 2. Clamp the up/down rotation so you can't backflip the camera
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 3. Apply rotation using Euler angles to guarantee the Z-axis stays at 0
        this.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}