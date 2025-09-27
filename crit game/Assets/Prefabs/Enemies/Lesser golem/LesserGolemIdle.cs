using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class LesserGolemIdle : Enemy
{
    //Value variables
    private float maxWanderDistance = 10f;
    private Vector3 newDestination;
    private bool coroutineRunning;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //Golem waits 3-5 seconds before moving to newDestination
    IEnumerator WaitAndMove()
    {
        float idleTime = Random.Range(3f, 5f);
        yield return new WaitForSeconds(idleTime);
        agent.SetDestination(newDestination);
        coroutineRunning = false;
    }

    //Idle behavior
    public void IdleBehavior()
    {
        //If golem is close enough to destination, generate new destination
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            //Checks if golem isn't already waiting
            if (coroutineRunning == false)
            {
                //If new destination is found, start coroutine
                if (GetRandomPoint(transform.position, maxWanderDistance, out newDestination))
                {
                    coroutineRunning = true;
                    StartCoroutine(WaitAndMove());
                }
            }
        }
    }

    //Gets new random destination within e_wanderDistance
    bool GetRandomPoint(Vector3 currentPosition, float range, out Vector3 agentRandomTarget)
    {
        for (int i = 0; i < 30; i++)
        {
            //Stores potential new destination
            NavMeshHit hit;

            //Get random point around the golem with Random.insideUnitSphere, range determines size of the sphere
            Vector3 randomPoint = currentPosition + Random.insideUnitSphere * range;

            //Turn randomPoint into vector3 on the navmesh for agent.destination
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                agentRandomTarget = hit.position;
                return true;
            }
        }

        //If valid point isn't found, sets destination to current position
        agentRandomTarget = transform.position;
        return false;
    }
}
