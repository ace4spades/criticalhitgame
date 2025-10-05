using UnityEngine;

public class Killbox : MonoBehaviour
{
    private PlayerHitManager player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerHitManager>();
    }

    //Killbox is on a specific layer that will only collide with players
    private void OnTriggerEnter(Collider other)
    {
        player.TakeDamage(Mathf.Infinity);
    }
}
