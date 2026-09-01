using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.8f; //earth

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


    void Update()
    {
        Vector3 move = new Vector3(moveInput.x,0,moveInput.y);
        controller.Move(move * speed * Time.deltaTime);
    }
}
