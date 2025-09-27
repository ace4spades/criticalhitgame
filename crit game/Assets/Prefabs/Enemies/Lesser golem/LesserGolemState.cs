using System.Runtime.CompilerServices;
using UnityEngine;

public class LesserGolemState : Enemy
{
    //State machine: Enum
    [SerializeField] public enum State
    {
        Idle,
        Aggresive,
        Frenzy
    }
    public State state;

    //Reference variables
    private LesserGolemIdle idleBehavior;
    private LesserGolemSearch searchBehavior;

    private LesserGolemAggressive aggressiveBehavior;

    private void Start()
    {
        idleBehavior = GetComponent<LesserGolemIdle>();
        aggressiveBehavior = GetComponent<LesserGolemAggressive>();
        searchBehavior = GetComponent <LesserGolemSearch>();
    }



    public void Update()
    {
        //State machine: Switch statement
        switch(state)
        {
            case State.Idle:
                idleBehavior.IdleBehavior();
                searchBehavior.LookingForPlayer();
                break;

            case State.Aggresive:
                aggressiveBehavior.AggressiveBehavior();
                break;

            case State.Frenzy:
                Debug.Log("Frenzy");
                break;
        }
    }
}
