using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSwitcher : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        _player.SetShooter(new RayShooter(new DamageEffect(10), _layerMask));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player.SetShooter(new RayShooter(new ExplotionEffect(new DamageEffect(20), 4), _layerMask));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _player.SetShooter(new RayShooter(new DamageEffect(10), _layerMask));
        }
    }
}
