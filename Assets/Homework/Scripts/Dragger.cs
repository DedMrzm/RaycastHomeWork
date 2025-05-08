using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Dragger : MonoBehaviour, IInteractor
{
    private KeyCode InteractKey = KeyCode.Mouse0;

    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private GameObject _draggedGameObject;

    private bool _isDragging;

    private Vector3 _draggingPosition;

    private float _distanceToCamera; 

    private void Update()
    {
        if (Input.GetKeyDown(InteractKey))
        {
            Interact();
        }

        if (_isDragging && _draggedGameObject != null)
        {
            Drag();
        }
    }

    public void Interact()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out RaycastHit hit, Mathf.Infinity, _layerMask))
        {
            if (_draggedGameObject == null)
            {
                Take(hit.collider.gameObject);
            }
            else
            {
                ThrowAway();
            }
        }
        else
        {
            ThrowAway();
        }
    }

    private void Take(GameObject gameObject)
    {
        _draggedGameObject = gameObject;

        _isDragging = true;

        _distanceToCamera = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
    }
    private void ThrowAway()
    {
        _isDragging = false;
        _draggedGameObject = null;
    }

    private void Drag()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, _distanceToCamera));

        _draggedGameObject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);
    }


}
