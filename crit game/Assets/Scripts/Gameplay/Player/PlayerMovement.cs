using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private UpdatedInputHandler inputHandler;
    private PlayerValues playerValues;
    private CharacterController controller;

    private void Start()
    {
        inputHandler = GetComponent<UpdatedInputHandler>();
        playerValues = GetComponent<PlayerValues>();
        controller = GetComponent<CharacterController>();
    }

    //Movement
    private void Update()
    {
        //Keeps player looking forward
        transform.rotation = Quaternion.Euler(transform.rotation.x, Camera.main.transform.eulerAngles.y, transform.rotation.z);
        
        //XY > XZ
        Vector3 moveInput = ((transform.forward * inputHandler.direction.y) + (transform.right * inputHandler.direction.x)).normalized;
        
        //Move player in the direction of moveinput
        controller.Move(moveInput * playerValues.movementSpeed * Time.deltaTime);
    }
}
