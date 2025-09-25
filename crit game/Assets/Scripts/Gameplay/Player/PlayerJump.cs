using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerJump : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;
    private PlayerValues playerValues;

    //Value variables
    private LayerMask world;
    public bool onGrounded;
    bool canDoubleJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerValues = GetComponent<PlayerValues>();
        world = LayerMask.GetMask("World");
    }

    //Jump logic
    //public void Jump()
    //{
    //    //First jump
    //    if (onGrounded == true)
    //    {
    //        //rb.AddForce(Vector3.up * playerValues.jumpHeight, ForceMode.Impulse);
    //        rb.linearVelocity = new Vector3(rb.linearVelocity.x, playerValues.jumpHeight, rb.linearVelocity.z);
    //        canDoubleJump = true;
    //    }
    //    //Second jump
    //    if (onGrounded == false && canDoubleJump == true)
    //    {
    //        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
    //        //rb.AddForce(Vector3.up * playerValues.jumpHeight * 0.9f, ForceMode.Impulse);
    //        rb.linearVelocity = new Vector3(rb.linearVelocity.x, playerValues.jumpHeight * 0.9f, rb.linearVelocity.z);
    //        canDoubleJump = false;
    //    }
    //}

    //private void Update()
    //{
    //    //Ground check
    //    onGrounded = Physics.BoxCast(transform.position + Vector3.down * 0.5f, new Vector3(0.5f, 0.1f, 0.5f), Vector3.down, Quaternion.identity, 0.4f, world);
    //}
}
