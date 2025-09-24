using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;
    private UpdatedInputHandler inputHandler;
    private Transform playerCam;
    [SerializeField] private PlayerValues playerValues;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<UpdatedInputHandler>();
        playerCam = Camera.main.transform;
    }

    private void Update()
    {
        //Keeps the player looking forward
        transform.rotation = Quaternion.Euler(transform.rotation.x, playerCam.eulerAngles.y, transform.rotation.z);

        //Movement logic
        Vector3 moveInput = ((transform.forward * inputHandler.direction.y) + (transform.right * inputHandler.direction.x)).normalized;
        transform.Translate(moveInput * (inputHandler.direction.magnitude * playerValues.movementSpeed) * Time.deltaTime, Space.World);
    }

    
    private void FixedUpdate()
    {
        ////Translate XY > XZ
        Vector3 moveInput = ((transform.forward * inputHandler.direction.y) + (transform.right * inputHandler.direction.x)).normalized;

        //Velocity application
        //rb.linearVelocity = Vector3.zero;
        //rb.MovePosition(moveInput * (inputHandler.direction.magnitude * playerValues.movementSpeed) * Time.fixedDeltaTime);
    }
}
