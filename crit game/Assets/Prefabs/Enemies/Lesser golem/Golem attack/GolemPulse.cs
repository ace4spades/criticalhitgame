using UnityEngine;

public class GolemPulse : MonoBehaviour
{
    //Reference variables
    private PlayerHitManager playerHitManager;

    //Value variables
    private float destroyTimer = 0.5f;
    void Start()
    {
        playerHitManager = FindFirstObjectByType<PlayerHitManager>();
    }
    private void Update()
    {
        Destroy(gameObject, destroyTimer);
    }

    public void OnTriggerEnter(Collider player)
    {
        Debug.Log(player.name);
        playerHitManager.TakeDamage(2f);
    }
}
