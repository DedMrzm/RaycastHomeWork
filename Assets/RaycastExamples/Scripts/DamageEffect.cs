using UnityEngine;

public class DamageEffect : IShootEffect
{
    private int _damage;

    public DamageEffect(int damage)
    {
        _damage = damage;
    }

    public void Execute(Vector3 point, Collider collider)
    {
        IDamageable1 damageable = collider.GetComponent<IDamageable1>();

        if (damageable != null)
            damageable.TakeDamage(_damage);
    }
}
