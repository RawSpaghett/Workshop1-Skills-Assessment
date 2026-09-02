using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.8f; //earth
    [SerializeField] private Commando commando;

    //Movement  
    private CharacterController controller;
    private Vector3 moveInput;
    private Vector3 velocity;

    //UI
    [SerializeField] private GameObject OText;
    [SerializeField] private GameObject PText;
    [SerializeField] private GameObject UICanvas;
    private bool UISwitch = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    //movement
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }

    //UI
    public void OnPopup(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(UICanvas.activeSelf) UICanvas.SetActive(false);
            else UICanvas.SetActive(true);

            if(context.control.name == "o")
            {
                PText.SetActive(false);
                OText.SetActive(true);
            }
            if (context.control.name == "p")
            {
                OText.SetActive(false);
                PText.SetActive(true);
            }
        }
        
    }

    //Missile

    public void OnWeapon(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(context.control.name == "r")
            {
                commando.Reload();
                Debug.Log("Commando.Reset() via OnWeapon");
            }

            if(context.control.name == "leftButton")
            {
                commando.PrimaryFire();
                Debug.Log("Primary fire via OnWeapon");
            }
            if(context.control.name == "rightButton")
            {
                commando.SecondaryFire();
                Debug.Log("Secondary fire via OnWeapon");
            }
        }
    }


    void Update()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);
    }
}
