using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Transform playerCam;
    [SerializeField] private PlayerValues playerValues;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerCam = Camera.main.transform;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, playerCam.eulerAngles.y, transform.rotation.z);
    }
    //Movement logic
    private void FixedUpdate()
    {
        Vector3 camForward = playerCam.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = playerCam.right;
        camRight.y = 0f;
        camRight.Normalize();

        ////Translate XY > XZ
        Vector3 moveInput = (camForward * playerInput.direction.y + camRight * playerInput.direction.x).normalized;
        Debug.Log(moveInput);

        //Velocity application
        rb.linearVelocity = Vector3.zero;
        rb.linearVelocity = (moveInput * (playerInput.direction.magnitude * playerValues.movementSpeed)) * Time.fixedDeltaTime;
    }
}
