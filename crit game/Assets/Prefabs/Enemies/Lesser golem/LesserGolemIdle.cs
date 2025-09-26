using UnityEngine;
using UnityEngine.AI;

public class LesserGolemIdle : Enemy
{
    //Value variables
    private bool hasDestination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void IdleBehavior()
    {
        if (hasDestination == false)
        {
            agent.destination = new Vector3();
            hasDestination = true;
        }
    }
}
