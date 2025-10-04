using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //Reference variables
    private Camera playerCam;
    private LayerMask enemyMask;
    private PlayerValues playerValues;
    private AudioManager audioManager;
    private void Start()
    {
        //MOVE THIS TO OTHER SCRIPT
        Cursor.lockState = CursorLockMode.Locked;

        playerCam = Camera.main;
        enemyMask = LayerMask.GetMask("Attack targets");
        playerValues = GetComponent<PlayerValues>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void Update()
    {
        playerValues.attackCooldown -= Time.deltaTime;
    }
    public void GetTarget()
    {
        //Make a ray from your camera to your cursor
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Fires a ray to your cursor. If the ray hits an enemy's target trigger, it will run a TakeDamage method on the parent (enemy)
        //Has a short cooldown to prevent spamming using playerValues.attackCooldown
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyMask) && playerValues.attackCooldown <= 0)
        {
            HitManagerGolem target = hit.collider.GetComponentInParent<HitManagerGolem>();
            audioManager.PlaySFX(audioManager.playerAttackSFX);
            target.TakeDamage(playerValues.damage);
            playerValues.attackCooldown = 0.5f;
        } 
    }
}
