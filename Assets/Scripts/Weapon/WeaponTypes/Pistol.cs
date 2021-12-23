using System.Collections.Generic;
using UnityEngine;

public sealed class Pistol : Weapon
{
    [SerializeField] private int _magazineCapacity;
    [SerializeField] private float _timeBeetwenShoots;
    private float _elapsedTime;


    private void Start()
    {
        LoadMagazine(_magazineCapacity);
        _elapsedTime = _timeBeetwenShoots;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public override void Shoot(Vector3 targetPoint)
    {
        if (_timeBeetwenShoots <= _elapsedTime)
        {
            if (TryGetObject(out GameObject bullet))
            {
                bullet.transform.position = BarrelCut.position;
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().Fly(targetPoint);
                _elapsedTime = 0;
            }
        }

        if (_bulletsInMagazine.Count <= 0)
        {
            LoadMagazine(_magazineCapacity);
        }
    }
}
