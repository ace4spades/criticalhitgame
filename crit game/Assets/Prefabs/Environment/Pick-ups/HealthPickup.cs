using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private AudioManager audioManager;
    private PlayerValues playerValues;
    [SerializeField] GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        playerValues = FindFirstObjectByType<PlayerValues>();

        //Effects and feedback
        Instantiate(particle, transform.position, Quaternion.identity);
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
