using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerHitManager : MonoBehaviour
{
    //Reference variables
    private PlayerValues playerValues;

    private void Start()
    {
        playerValues = GetComponent<PlayerValues>();
    }

    //Death check
    private void Update()
    {
        if (playerValues.playerCurrentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }

    //Taking damage logic
    public void TakeDamage(float incomingDamage)
    {
        playerValues.playerCurrentHealth -= incomingDamage;
    }
}
