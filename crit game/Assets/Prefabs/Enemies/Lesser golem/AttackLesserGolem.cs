using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AttackLesserGolem : Enemy
{
    //Reference variables
    [SerializeField] GameObject golemPulse;
    private ChaseLesserGolem chase;
    private StateMachineGolem stateMachine;

    //Value variables
    private bool coroutineRunning;
    private float attackSpeed = 1f;
    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(attackSpeed);

        //Instantiate the pulse at golem center
        Instantiate(golemPulse, new Vector3(transform.position.x, transform.position.y + 2.044939f, transform.position.z), Quaternion.identity);

        coroutineRunning = false;
        yield return null;
    }

    private void Start()
    {
        chase = GetComponent<ChaseLesserGolem>();
        stateMachine = GetComponent<StateMachineGolem>();
    }
    public void AttackPlayer()
    {
        if (coroutineRunning == false)
        {
            coroutineRunning = true;
            StartCoroutine(AttackCoroutine());
        }

        if (Vector3.Distance(transform.position, chase.playerTransform.position) >= chase.attackRange)
        {
            StopCoroutine(AttackCoroutine());
            stateMachine.state = StateMachineGolem.State.Chasing;
        }
    }
}
