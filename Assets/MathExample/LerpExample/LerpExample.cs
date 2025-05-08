using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpExample : MonoBehaviour
{
    [SerializeField] private Transform _rightLimit;
    [SerializeField] private Transform _leftLimit;
    [SerializeField] private Transform _target;

    private float _progress;

    private void Update()
    {
        Debug.Log(_progress);
        if (Input.GetKey(KeyCode.W))
            _progress += Time.deltaTime;

        if(Input.GetKey(KeyCode.S))
            _progress -= Time.deltaTime;

        _target.position = Vector3.Lerp(_leftLimit.position, _rightLimit.position, _progress * _progress);

        _target.rotation = Quaternion.Lerp(_leftLimit.rotation, _rightLimit.rotation, _progress);
    }
}
