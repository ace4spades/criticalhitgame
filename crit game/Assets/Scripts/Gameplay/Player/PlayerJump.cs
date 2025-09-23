using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private InputHandler inputHandler;

    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    private void Jump()
    {
        Debug.Log("Attempting to addforce");
    }
}
