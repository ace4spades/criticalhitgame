using UnityEngine;
using System.Collections;
public class PlayerHitManager : MonoBehaviour
{
    //Reference variables
    private PlayerValues playerValues;

    private void Start()
    {
        playerValues = GetComponent<PlayerValues>();
    }

    public void TakeDamage(float incomingDamage)
    {
        playerValues.playerCurrentHealth -= incomingDamage;
    }
}
