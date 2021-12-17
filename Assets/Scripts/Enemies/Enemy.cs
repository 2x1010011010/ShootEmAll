using UnityEngine;

[RequireComponent(typeof(EnemyRagdoll))]
public class Enemy : MonoBehaviour
{
    private EnemyRagdoll _ragdoll;

    public void Start()
    {
        _ragdoll = GetComponent<EnemyRagdoll>();
    }

    public void Die()
    {
        _ragdoll.SetDamage();
    }
}
