using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingPoint : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemiesOnPoint;

    public int EnemiesCount => _enemiesOnPoint.Count;
    
    public void RemoveKilled(GameObject enemy)
    {
        _enemiesOnPoint.Remove(enemy.GetComponent<Enemy>());
    }
}
