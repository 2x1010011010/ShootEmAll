using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected GameObject Magazine;
    [SerializeField] protected Transform BarrelCut;
    private List<GameObject> _magazine = new List<GameObject>();

    public abstract void Shoot(Vector3 direction);

    protected void LoadMagazine(int magazineCapacity)
    {
        for (int i = 0; i < magazineCapacity; i++)
        {
            GameObject spawned = Instantiate(Bullet.gameObject, Magazine.transform);
            spawned.SetActive(false);

            _magazine.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _magazine.FirstOrDefault(p => p.activeSelf == false);
        _magazine.Remove(result);

        return result != null;
    }
}
