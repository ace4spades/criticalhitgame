using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class LesserGolemAggressive : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void AggressiveBehavior()
    {
        agent.SetDestination(Vector3.zero);
    }
}
