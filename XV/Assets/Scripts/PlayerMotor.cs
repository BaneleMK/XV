using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 1f;
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    public void FollowTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void StopFollowTarget()
    {
        target = null;
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
