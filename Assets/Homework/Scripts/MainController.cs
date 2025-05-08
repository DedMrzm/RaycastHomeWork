using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private IInteractor _interactor;

    private IExploider _exploider;
    
    private KeyCode ExplosionKey = KeyCode.Mouse1;

    private void Awake()
    {
        _exploider = new Exploder();
    }

    private void Update()
    {

    }
}
