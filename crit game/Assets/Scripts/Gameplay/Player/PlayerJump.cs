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
    public bool canJump;
    [SerializeField] private float coyoteTime = 1f;
    private float groundDrag;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerValues = GetComponent<PlayerValues>();
        world = LayerMask.GetMask("World");
    }

    public void Jump()
    {
        if (canJump == true)
        {
            onGrounded = false;
            rb.AddForce(Vector3.up * playerValues.jumpHeight);
            coyoteTime = 0f;
            Debug.Log("Jumped");
        }
    }

    private void Update()
    {
        onGrounded = Physics.BoxCast(transform.position + Vector3.down * 0.5f, new Vector3(0.5f, 0.1f, 0.5f), Vector3.down, Quaternion.identity, 0.4f, world);
        if (onGrounded == false)
        {
            coyoteTime -= Time.deltaTime;
            if (coyoteTime < 0)
            {
                canJump = false;
            }
        }
        if (onGrounded == true)
        {
            coyoteTime = 1f;
            canJump = true;
        }
    }
}
