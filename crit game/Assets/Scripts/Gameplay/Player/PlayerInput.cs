using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //Value variables
    public Vector2 direction;

    //WASD input > Vector2 translator
    private void OnMovement(InputValue input)
    {
        direction = input.Get<Vector2>();
        Debug.Log(direction);
;   }
}
