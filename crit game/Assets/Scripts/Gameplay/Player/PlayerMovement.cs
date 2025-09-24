using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;
    private UpdatedInputHandler inputHandler;
    private Transform playerCam;
    private PlayerValues playerValues;
    private PlayerJump playerJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<UpdatedInputHandler>();
        playerCam = Camera.main.transform;
        playerValues = GetComponent<PlayerValues>();
        playerJump = GetComponent<PlayerJump>();
    }

    private void Update()
    {
        //Keeps the player looking forward
        transform.rotation = Quaternion.Euler(transform.rotation.x, playerCam.eulerAngles.y, transform.rotation.z);
        Debug.Log(playerJump.onGrounded);
    }

    
    private void FixedUpdate()
    {
        ////Translate XY > XZ
        Vector3 moveInput = ((transform.forward * inputHandler.direction.y) + (transform.right * inputHandler.direction.x)).normalized;

        //Velocity application
        rb.AddForce(moveInput * (inputHandler.direction.magnitude * playerValues.movementSpeed));
    }
}
