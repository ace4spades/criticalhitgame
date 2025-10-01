using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private void Start()
    {
        //MOVE THIS TO PAUSING/OTHER SCRIPT
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void GetTarget()
    {
        Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        //Debug.Log(ray.direction);
    }
}
