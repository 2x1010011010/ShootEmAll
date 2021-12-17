using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public sealed class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _rigidBodies;
    [SerializeField] private Animator _animator;
    [SerializeField] private ShootingPoint _point;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _animator.enabled = true;
        foreach (var rigidbody in _rigidBodies)
            rigidbody.isKinematic = true;
    }

    public void SetDamage()
    {
        _animator.enabled = false;
        _point.RemoveKilled(_enemy);
        foreach (var rigidbody in _rigidBodies)
            rigidbody.isKinematic = false;
    }
}
