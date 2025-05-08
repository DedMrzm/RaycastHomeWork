using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionShooter : IShooter
{
    private int _damage;

    private float _explotionRadius;

    public ExplotionShooter(int damage, float explotionRadius)
    {
        _damage = damage;
        _explotionRadius = explotionRadius;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Collider[] targets = Physics.OverlapSphere(hit.point, _explotionRadius);

            foreach(Collider target in targets)
            {
                IDamageable1 damageable = target.GetComponent<IDamageable1>();

                if (damageable != null) 
                    damageable.TakeDamage(_damage);
            }
        }
    }
}
