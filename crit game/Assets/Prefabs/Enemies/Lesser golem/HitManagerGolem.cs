using Unity.VisualScripting;
using UnityEngine;

public class HitManagerGolem : MonoBehaviour
{
    private GolemValues golemValues;

    private void Start()
    {
        golemValues = GetComponent<GolemValues>();
    }
    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        golemValues.currentHealth = golemValues.currentHealth - damage;
    }

    private void Update()
    {
        if (golemValues.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
