using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private UpdatedInputHandler inputHandler;
    private PlayerValues playerValues;
    private PlayerJump playerJump;
    private CharacterController controller;
    private void Start()
    {
        inputHandler = GetComponent<UpdatedInputHandler>();
        playerValues = GetComponent<PlayerValues>();
        playerJump = GetComponent<PlayerJump>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Keeps player looking forward
        transform.rotation = Quaternion.Euler(transform.rotation.x, Camera.main.transform.eulerAngles.y, transform.rotation.z);
        
        //Movement logic
        Vector3 moveInput = ((transform.forward * inputHandler.direction.y) + (transform.right * inputHandler.direction.x)).normalized;

        controller.Move(moveInput * (inputHandler.direction.magnitude * playerValues.movementSpeed) * Time.deltaTime);
    }




































    //private void FixedUpdate()
    //{
    //    //Applies downward force to prevent player from floating
    //    if (playerJump.onGrounded == false)
    //    {
    //        rb.AddForce(playerGravity * Vector3.down);
    //    }

    //    ////Translate XY > XZ
    //    Vector3 moveInput = ((transform.forward * inputHandler.direction.y) + (transform.right * inputHandler.direction.x)).normalized;

    //    //Rigidbody movement
    //    rb.AddForce(moveInput * (inputHandler.direction.magnitude * playerValues.movementSpeed), ForceMode.VelocityChange);

    //    //Lerp velocity to 0 to prevent skating
    //    if (inputHandler.direction == Vector2.zero)
    //    {
    //       // Vector3 groundVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
    //       // rb.linearVelocity = Vector3.Lerp(groundVelocity, Vector3.zero, 0.5f);
    //    }
    //}

    //Counter force, prevents slippery movement
    //public void CounterForce()
    //{
    //    Vector3 reverseMoveInput = ((-transform.forward * inputHandler.direction.y) + (-transform.right * inputHandler.direction.x).normalized);
    //    rb.AddForce(reverseMoveInput * 150f, ForceMode.Force);
    //    //inputHandler.direction = Vector2.zero;
    //}
}
