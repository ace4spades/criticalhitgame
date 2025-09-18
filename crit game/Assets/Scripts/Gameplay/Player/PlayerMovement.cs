using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Transform playerCam;

    //Value variables
    [SerializeField] float movementSpeed = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerCam = Camera.main.transform;
    }

    private void Update()
    {
        //transform.rotation = Quaternion.Euler(transform.rotation.x, playerCam.eulerAngles.y, transform.rotation.z);
    }
    //Movement logic
    private void FixedUpdate()
    {
        //Translate the XY of direction variable into usable vector3 for movement
        Vector3 moveInput = new Vector3(playerInput.direction.x, 0f, playerInput.direction.y);
        rb.linearVelocity = new Vector3((moveInput.x * movementSpeed), 0f, (moveInput.z * movementSpeed)) * Time.deltaTime;

        
    }
}
