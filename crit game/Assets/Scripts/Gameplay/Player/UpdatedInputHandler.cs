using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpdatedInputHandler : MonoBehaviour
{
    //Reference variables
    public InputActionAsset playerInput;
    private PlayerActionMap controls;
    private PlayerJump playerJump;
    //Value variables
    public Vector2 direction;

    private void Awake()
    {
        controls = new PlayerActionMap();
        controls.Player.Movement.performed += OnMovement;
        controls.Player.Movement.canceled += OnMovementCancel;
        controls.Player.Jump.performed += OnJump;
    }

    private void Start()
    {
        playerJump = GetComponent<PlayerJump>();
    }
    //Enables/Disables "Player" action map
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

    //Player input events
    private void OnMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    private void OnMovementCancel(InputAction.CallbackContext context)
    {
        direction = new Vector2(0f, 0f);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        playerJump.Jump();
    }
}
