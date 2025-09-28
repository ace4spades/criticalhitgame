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
    private float jumpBuffer = 0.25f;
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
    }


    public void Jump()
    {
        //1st jump
        if (controller.isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(playerValues.jumpHeight * -2f * gravity);
            canDoubleJump = true;
        }
        //2nd jump
        if (controller.isGrounded == false && jumpBuffer < 0)
        {
            velocity.y = Mathf.Sqrt((playerValues.jumpHeight * 0.9f) * -2f * gravity);
            canDoubleJump = false;
            jumpBuffer = 0.25f;
        }
    }
}
