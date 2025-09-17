using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;
    private PlayerInput playerInput;

    //Value variables
    [SerializeField] float movementSpeed = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    //Movement logic
    private void FixedUpdate()
    {
        //Translate the XY of direction variable into usable vector3 for movement
        Vector3 moveInput = new Vector3(playerInput.direction.x, 0f, playerInput.direction.y);


    }
}
