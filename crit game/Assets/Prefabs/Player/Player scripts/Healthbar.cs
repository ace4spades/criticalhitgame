using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    private PlayerValues playerValues;
    public Slider healthbar;

    private void Start()
    {
        healthbar = GetComponent<Slider>();
        playerValues = FindFirstObjectByType<PlayerValues>();
    }

    //Set the slider value to the players current health
    private void Update()
    {
        healthbar.value = playerValues.playerCurrentHealth;
    }
}
