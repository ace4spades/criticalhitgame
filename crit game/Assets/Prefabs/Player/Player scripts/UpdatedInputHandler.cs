using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LightTransport;

public class UpdatedInputHandler : MonoBehaviour
{
    //Reference variables
    public InputActionAsset playerInput;
    private PlayerActionMap controls;
    private PlayerJump playerJump;
    private PlayerMovement playerMovement;
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
        playerMovement = GetComponent<PlayerMovement>();
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
        direction = Vector2.zero;
        //playerMovement.CounterForce();
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        playerJump.Jump();
    }
}
