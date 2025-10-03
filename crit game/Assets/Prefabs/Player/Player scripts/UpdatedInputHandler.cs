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
    private PlayerAttack playerAttack;
    public Animator animator;

    //Value variables
    public Vector2 direction;


    private void Awake()
    {
        controls = new PlayerActionMap();
        controls.Player.Movement.performed += OnMovement;
        controls.Player.Movement.canceled += OnMovementCancel;
        controls.Player.Jump.performed += OnJump;
        controls.Player.Attackinitiate.performed += OnAttackInitiate;
    }

    private void Start()
    {
        playerJump = GetComponent<PlayerJump>();
        playerAttack = GetComponent<PlayerAttack>();
        animator = GetComponentInChildren<Animator>();
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
        animator.SetBool("isMoving", true);
        Debug.Log(animator.GetBool("isMoving"));
        direction = context.ReadValue<Vector2>();
    }
    private void OnMovementCancel(InputAction.CallbackContext context)
    {
        animator.SetBool("isMoving", false);
        direction = Vector2.zero;
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        playerJump.Jump();
    }

    private void OnAttackInitiate(InputAction.CallbackContext context)
    {
        playerAttack.GetTarget();
    }
}
