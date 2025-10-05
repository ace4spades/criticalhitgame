using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    //Value variables
    [SerializeField] public float playerMaxHealth;
    [SerializeField] public float playerCurrentHealth;

    [SerializeField] public float movementSpeed;
    [SerializeField] public float jumpHeight;

    [SerializeField] public float damage;
    [SerializeField] public float attackCooldown;
    [SerializeField] public float attackRange;
}
