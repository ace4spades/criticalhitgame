using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;
    private InputHandler inputHandler;
    private Transform playerCam;
    [SerializeField] private PlayerValues playerValues;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        playerCam = Camera.main.transform;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, playerCam.eulerAngles.y, transform.rotation.z);
    }
    //Movement logic
    private void FixedUpdate()
    {
        ////Translate XY > XZ
        Vector3 moveInput = ((transform.forward * inputHandler.direction.y) + (transform.right * inputHandler.direction.x)).normalized;

        //Velocity application
        rb.linearVelocity = Vector3.zero;
        rb.linearVelocity = (moveInput * (inputHandler.direction.magnitude * playerValues.movementSpeed)) * Time.fixedDeltaTime;
    }
}
