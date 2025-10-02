using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.AI;
public class SearchLesserGolem : Enemy
{
    //Value variables
    private bool coroutineRunning;
    private LayerMask playerMask;
    private float aggroRange = 30f;

    //Reference variables
    private StateMachineGolem stateMachine;
    private NavMeshAgent agent;
    private GolemValues golemValues;

    private void Start()
    {
        playerMask = LayerMask.GetMask("Player");
        stateMachine = GetComponent<StateMachineGolem>();
        agent = GetComponent<NavMeshAgent>();
        golemValues = GetComponent<GolemValues>();
    }
    //Detection logic
    IEnumerator Searching()
    {
        yield return new WaitForSeconds(0.2f);

        //Detection spherecast
        Collider[] playersSpotted = Physics.OverlapSphere(transform.position, aggroRange, playerMask);
        //If player is spotted: start chasing
        if (playersSpotted.Length > 0)
        {
            agent.ResetPath();
            agent.speed = golemValues.chaseSpeed;
            stateMachine.state = StateMachineGolem.State.Chasing;
            StopCoroutine(Searching());
        }
        //If player isn't spotted: return null
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
}
