using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerJump : MonoBehaviour
{
    //Reference variables
    private PlayerValues playerValues;
    private CharacterController controller;
    [SerializeField] ParticleSystem doubleJumpParticle;

    //Value variables
    private float gravity = -20f;
    private Vector3 velocity;
    private bool canDoubleJump = false;
    private void Start()
    {
        playerValues = GetComponent<PlayerValues>();
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //Gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        if (velocity.y < 0)
        {
            velocity.y += gravity * 2f * Time.deltaTime;
        } else
        {
            velocity.y += gravity * Time.deltaTime;

        }
        controller.Move(velocity * Time.deltaTime);
    }


    public void Jump()
    {
        if (controller.isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(playerValues.jumpHeight * -2f * gravity);
            canDoubleJump = true;
        }
        if (controller.isGrounded == false && canDoubleJump == true)
        {
            velocity.y = Mathf.Sqrt((playerValues.jumpHeight * 0.9f) * -2f * gravity);
            canDoubleJump = false;
        }
    }
}
