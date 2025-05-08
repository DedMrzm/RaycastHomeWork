using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    [SerializeField] private ParticleSystem _destroyEffect;

    public void TakeDamage(float damage)
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
