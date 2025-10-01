using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineGolem : Enemy
{
    //State machine: Enum
    public enum State
    {
        Idle,
        Chasing,
        Attacking
    }
    [SerializeField] public State state;

    //Reference variables
    private IdleWanderLesserGolem wander;
    private SearchLesserGolem search;
    private ChaseLesserGolem chase;
    private AttackLesserGolem attack;

    private void Start()
    {
        wander = GetComponent<IdleWanderLesserGolem>();
        search = GetComponent<SearchLesserGolem>();
        chase = GetComponent<ChaseLesserGolem>();
        attack = GetComponent<AttackLesserGolem>();
    }



    public void Update()
    {
        //State machine: Switch statement
        switch(state)
        {
            case State.Idle:
                wander.IdleWander();
                search.LookingForPlayer();
                break;

            case State.Chasing:
                chase.ChasePlayer();
                break;

            case State.Attacking:
                attack.AttackPlayer();
                break;
        }
    }
}
