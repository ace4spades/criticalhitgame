using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private AudioManager audioManager;
    private PlayerValues playerValues;
    private void OnTriggerEnter(Collider other)
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        playerValues = FindFirstObjectByType<PlayerValues>();


        audioManager.PlaySFX(audioManager.healthPickupSFX);
        //Particle effect
        playerValues.playerCurrentHealth += 20;

        //Prevents overheal
        if (playerValues.playerCurrentHealth > playerValues.playerMaxHealth)
        {
            playerValues.playerCurrentHealth = playerValues.playerMaxHealth;
        }
        Destroy(gameObject);
    }
}
