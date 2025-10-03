using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);
    }
}
