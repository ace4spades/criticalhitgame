using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
public class LesserGolemSearch : Enemy
{
    //Value variables
    private bool coroutineRunning;
    private LayerMask playerMask;
    private float aggroRange = 30f;

    //Reference variables
    private LesserGolemState stateMachine;

    private void Start()
    {
        playerMask = LayerMask.GetMask("Player");
        stateMachine = GetComponent<LesserGolemState>();
    }
    //Detection logic
    IEnumerator Searching()
    {
        yield return new WaitForSeconds(0.2f);

        //Detection spherecast
        Collider[] playersSpotted = Physics.OverlapSphere(transform.position, aggroRange, playerMask);
        if (playersSpotted.Length > 0)
        {
            Debug.Log("Player spotted");
            StopCoroutine(Searching());
            stateMachine.state = LesserGolemState.State.Aggresive;
        }


        coroutineRunning = false;
        yield return null;
    }

    public void LookingForPlayer()
    {
        //Prevents too many player checks
        if (coroutineRunning == false)
        {
            coroutineRunning = true;
            StartCoroutine(Searching());
        }
    }
    bool TargetWasFound(Vector3 enemyPosition, Vector3 playerPosition, out bool targetFound)
    {

        targetFound = false;
        return targetFound;
    }
}
