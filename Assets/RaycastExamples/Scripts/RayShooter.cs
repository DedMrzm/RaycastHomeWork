using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : IShooter
{
    private IShootEffect _shootEffect;
    private LayerMask _layerMask;

    public RayShooter(IShootEffect shootEffect, LayerMask layerMask)
    {
        _shootEffect = shootEffect;
        _layerMask = layerMask;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask.value))
        {
            _shootEffect.Execute(hit.point, hit.collider);
        }
    }
}

public class ProjectileShooter : IShooter
{
    public void Shoot(Vector3 origin, Vector3 direction)
    {
        
    }
}
