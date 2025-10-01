using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class ChaseLesserGolem : Enemy
{
    //Reference variables
    [SerializeField] public Transform playerTransform;
    private StateMachineGolem stateMachine;
    private NavMeshAgent agent;

    //Value variables
    public float attackRange = 3f;

    private void Start()
    {
        stateMachine = GetComponent<StateMachineGolem>();
        agent = GetComponent<NavMeshAgent>();
    }


    //Chase the player until they're in range
    public void ChasePlayer()
    {
        agent.SetDestination(playerTransform.position);

        if (Vector3.Distance(transform.position, playerTransform.position) <= attackRange)
        {
            agent.ResetPath();
            stateMachine.state = StateMachineGolem.State.Attacking;
        }
    }
}
