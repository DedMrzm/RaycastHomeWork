using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObstacleChecker))]
public class NonKinematicCharacter : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    private KeyCode JumpKey = KeyCode.Space;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private ObstacleChecker _groundChecker;

    private Vector2 _movementInput;
    private bool _isJumpPressed;

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(_movementInput.x, 0, _movementInput.y)); 

        if(_isJumpPressed && _groundChecker.IsTouches())
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumpPressed = false;
        }
    }

    private void ReadInput()
    {
        _movementInput = new Vector2(Input.GetAxisRaw(HorizontalAxisName), Input.GetAxisRaw(VerticalAxisName)).normalized;

        if (_isJumpPressed == false)
            _isJumpPressed = Input.GetKeyDown(JumpKey);
    }
}
