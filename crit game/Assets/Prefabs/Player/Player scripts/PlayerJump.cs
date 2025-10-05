using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerJump : MonoBehaviour
{
    //Reference variables
    private PlayerValues playerValues;
    private CharacterController controller;
    public Animator animator;

    //Value variables
    private float gravity = -20f;
    private Vector3 velocity;

    private bool canDoubleJump = false;
    private float jumpBuffer = 0.25f;

    private float coyoteTime = 0.1f;
    private float lastGroundedTime;

    private void Start()
    {
        playerValues = GetComponent<PlayerValues>();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        //Gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //If airborne > multiply fallrate, else fall normally.
        if (velocity.y < 0)
        {
            velocity.y += gravity * 1.5f * Time.deltaTime;
        } else
        {
            velocity.y += gravity * Time.deltaTime;

        }
        controller.Move(velocity * Time.deltaTime);

        //2nd jump buffer
        if (canDoubleJump == true)
        {
            jumpBuffer -= Time.deltaTime;
        } else
        {
            jumpBuffer = 0.25f;
        }

        //Air animation
        if (controller.isGrounded == false)
        {
            animator.SetBool("isAirborne", true);
        }
        if (controller.isGrounded == true)
        {
            animator.SetBool("isAirborne", false);
        }
    }


    public void Jump()
    {
        //1st jump
        if (controller.isGrounded == true || Time.time - lastGroundedTime <= coyoteTime)
        {
            velocity.y = Mathf.Sqrt(playerValues.jumpHeight * -2f * gravity);
            canDoubleJump = true;
        }
        //2nd jump
        if (controller.isGrounded == false && jumpBuffer < 0)
        {
            velocity.y = Mathf.Sqrt(playerValues.jumpHeight * -2f * gravity);
            canDoubleJump = false;
            jumpBuffer = 0.25f;
        }
    }
}
