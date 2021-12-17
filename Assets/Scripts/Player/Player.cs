using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    private Weapon _currentWeapon;


    private void Start()
    {
        _currentWeapon = _weapons[0];
    }

    public void PushTrigger(Vector3 direction) => _currentWeapon.Shoot(direction);
}
