using System.Runtime.CompilerServices;
using UnityEngine;

public class LesserGolemState : Enemy
{
    //State machine
    [SerializeField] public enum State
    {
        Idle,
        Aggresive,
        Frenzy
    }
    public State state;
    //Reference variables
    private LesserGolemIdle idleBehavior;
    private LesserGolemAggressive aggressiveBehavior;

    private void Start()
    {
        idleBehavior = GetComponent<LesserGolemIdle>();
        aggressiveBehavior = GetComponent<LesserGolemAggressive>();
    }

    private void Update()
    {
        switch(state)
        {
            case State.Idle:
                idleBehavior.IdleBehavior();
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
