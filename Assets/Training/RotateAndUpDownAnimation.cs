using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndUpDownAnimation : MonoBehaviour
{
    [SerializeField] private float _depthOfMovingUpDown;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private Vector3 _startPosition;
    private float _progress = 0f;
    private bool _increase = true;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        MoveUpAndDown();
        Rotate();
    }

    private void MoveUpAndDown()
    {
        if (_increase)
        {
            _progress += Time.deltaTime;
        }
        if (_increase == false)
        {
            _progress -= Time.deltaTime;
        }
        if (_progress >= 1)
        {
            _increase = false;
        }
        if (_progress <= 0)
        {
            _increase = true;
        }
        transform.position = Vector3.Lerp(new Vector3(_startPosition.x, _startPosition.y + _depthOfMovingUpDown, _startPosition.z), new Vector3(_startPosition.x, _startPosition.y - _depthOfMovingUpDown, _startPosition.z), _progress);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, _rotateSpeed + Time.deltaTime);
    }
}
