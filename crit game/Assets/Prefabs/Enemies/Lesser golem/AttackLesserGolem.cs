using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AttackLesserGolem : Enemy
{
    //Reference variables
    [SerializeField] GameObject golemPulse;
    private ChaseLesserGolem chase;
    private StateMachineGolem stateMachine;
    private GolemValues golemValues;

    //Value variables
    private bool coroutineRunning;

    //Attack logic
    IEnumerator AttackCoroutine()
    {
        //Instantiate the pulse at golem center
        Instantiate(golemPulse, new Vector3(transform.position.x, transform.position.y + 2.044939f, transform.position.z), Quaternion.identity, transform);

        //Give the attack a CD 
        yield return new WaitForSeconds(golemValues.attackSpeed);
        
        //End coroutine
        coroutineRunning = false;
        yield return null;
    }

    private void Start()
    {
        chase = GetComponent<ChaseLesserGolem>();
        stateMachine = GetComponent<StateMachineGolem>();
        golemValues = GetComponent<GolemValues>();
    }
    public void AttackPlayer()
    {
        //Start attack coroutine if it isn't already running
        if (coroutineRunning == false)
        {
            coroutineRunning = true;
            StartCoroutine(AttackCoroutine());
        }

        //If player moves out of range: Will start chasing
        if (Vector3.Distance(transform.position, chase.playerTransform.position) >= golemValues.attackRange)
        {
            StopCoroutine(AttackCoroutine());
            stateMachine.state = StateMachineGolem.State.Chasing;
        }
    }
}
