using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HitManagerGolem : MonoBehaviour
{
    private GolemValues golemValues;
    [SerializeField] public GameObject damageEffect;
    private void Start()
    {
        golemValues = GetComponent<GolemValues>();
    }
    public void TakeDamage(float damage)
    {
        Instantiate(damageEffect, new Vector3(transform.position.x, transform.position.y + 2.044939f, transform.position.z), Quaternion.identity);
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
