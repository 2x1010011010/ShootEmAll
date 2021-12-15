using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private float _speed;

    private NavMeshAgent _navigationAgent;

    public event UnityAction OnPointArrived;

    private void Start()
    {
        _navigationAgent = GetComponent<NavMeshAgent>();
        MoveToPoint();
    }

    public void MoveToPoint()
    {
        _navigationAgent.SetDestination(_wayPoints[1].position);
    }
}
