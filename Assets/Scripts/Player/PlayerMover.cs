using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public sealed class PlayerMover : MonoBehaviour
{
    private NavMeshAgent _navigationAgent;

    private void Awake()
    {
        _navigationAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        _navigationAgent.SetDestination(point);
    }

    public void LookAtEnemy(Vector3 direction)
    {
        transform.LookAt(direction);
    }
}
