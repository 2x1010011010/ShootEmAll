using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public sealed class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;

    public void DestroyBullet()
    {
        DOTween.KillAll();
        Destroy(this.gameObject);
    }
    public void Fly(Vector3 target)
    {
        transform.DOMove(target, Vector3.Distance(target, transform.position) / _speed);
    }
}
