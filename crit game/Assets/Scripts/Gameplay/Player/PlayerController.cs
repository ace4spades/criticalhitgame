using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Variables
    //References
    private PlayerController playerController;
    public InputAction moveAction;

    //Values
    private Vector2 direction;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        moveAction.performed += Move;
        moveAction.canceled += StopMove;
        moveAction.Enable();
    }


    private void Move(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard != null)
        {
            if(keyboard.wKey.wasPressedThisFrame)
            {
                Debug.Log("W pressed");
            }
        }
    }
}
