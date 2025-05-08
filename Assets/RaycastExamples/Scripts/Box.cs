using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1 : MonoBehaviour, IDamageable1
{
    [SerializeField] private ParticleSystem _destroyEffect;

    public void TakeDamage(int damage)
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
