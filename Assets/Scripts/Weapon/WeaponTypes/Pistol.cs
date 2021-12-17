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

    public override void Shoot(Vector3 direction)
    {
        if (_timeBeetwenShoots <= _elapsedTime)
        {
            if (TryGetObject(out GameObject bullet))
            {
                bullet.transform.position = BarrelCut.position;
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().Fly(direction);
                _elapsedTime = 0;
            }
        }
    }
}
