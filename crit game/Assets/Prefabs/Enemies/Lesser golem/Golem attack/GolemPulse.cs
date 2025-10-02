using UnityEngine;

public class GolemPulse : MonoBehaviour
{
    //Reference variables
    private PlayerHitManager playerHitManager;
    private GolemValues golemValues;

    private void Start()
    {
        playerHitManager = FindFirstObjectByType<PlayerHitManager>();
        golemValues = GetComponentInParent<GolemValues>();

        Destroy(gameObject, golemValues.attackLifespan);
    }


    //Trigger for the golem pulse attack
    public void OnTriggerEnter(Collider player)
    {
        playerHitManager.TakeDamage(golemValues.damage);
    }
}
