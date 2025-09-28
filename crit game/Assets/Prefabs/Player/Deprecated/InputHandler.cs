using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    //Value variables
    public Vector2 direction;
    public bool pressedJump = false;

    //WASD input > Vector2 translator
    private void OnMovement(InputValue input)
    {
        direction = input.Get<Vector2>();
    }

    //Jump input
    private bool OnJump()
    {
        pressedJump = true;
        return pressedJump;
    }
}
