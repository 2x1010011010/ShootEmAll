using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;
    public event UnityAction OnPointArrived;
    public event UnityAction OnFinishPointArrived;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out ShootingPoint _))
            OnPointArrived?.Invoke();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.TryGetComponent<FinishPoint>(out FinishPoint finishPoint))
            OnFinishPointArrived?.Invoke();
    }
}
