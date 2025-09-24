using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;
    private PlayerValues playerValues;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerValues = GetComponent<PlayerValues>();
    }

    public void Jump()
    {
        rb.AddForce(transform.up * 10f);
    }
}
