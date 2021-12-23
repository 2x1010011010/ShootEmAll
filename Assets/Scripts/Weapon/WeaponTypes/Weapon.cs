using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected GameObject Magazine;
    [SerializeField] protected Transform BarrelCut;
    protected List<GameObject> _bulletsInMagazine = new List<GameObject>();

    public abstract void Shoot(Vector3 targetPoint);

    protected void LoadMagazine(int magazineCapacity)
    {
        for (int i = 0; i < magazineCapacity; i++)
        {
            GameObject spawned = Instantiate(Bullet.gameObject, Magazine.transform);
            spawned.SetActive(false);

            _bulletsInMagazine.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _bulletsInMagazine.FirstOrDefault(p => p.activeSelf == false);
        _bulletsInMagazine.Remove(result);

        return result != null;
    }
}
