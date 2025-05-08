using UnityEngine;

public class PlayerExample : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private const float StopZone = 0.01f;

    private CharacterController _characterController;

    private Vector3 _startPosition;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private bool _isPlaying = true;

    public bool IsPlaying { get => _isPlaying; set => _isPlaying = value; }

    private void Awake()
    {
        _startPosition = transform.position;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_isPlaying)
        {
            Control();
        }
        
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    public void Restart()
    {
        transform.position = _startPosition;
        IsPlaying = true;
    }

    private void Control()
    {
        Vector3 input = new Vector3(-Input.GetAxisRaw(VerticalAxisName), 0, Input.GetAxisRaw(HorizontalAxisName));

        if (input.magnitude <= StopZone)
            return;

        Vector3 normalizedInput = input.normalized;

        ProcessMoveTo(normalizedInput);
        ProcessRotateTo(normalizedInput);
    }
}
