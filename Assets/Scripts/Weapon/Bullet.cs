using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public sealed class Bullet : MonoBehaviour
{
    [SerializeField] float _flyingTime;

    public void Destroy()
    {
        DOTween.KillAll();
    }
    public void Fly(Vector3 direction)
    {
        transform.DOMove(direction, _flyingTime);
    }
}
