using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference variables
    private Rigidbody rb;

    //Value variables
    [SerializeField] float movementSpeed = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
