using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bullet))]
public sealed class BulletCollisionHandler : MonoBehaviour
{
    private Bullet _bullet;

    private void Start()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Die();
            _bullet.Destroy();
            Destroy(gameObject);
        }
    }
}
