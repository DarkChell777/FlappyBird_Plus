using System;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] private GameObject _bird;
    [SerializeField] private InputManager _input;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    [Header("Настройки подбрасывания")]
    [SerializeField] private float _maxFallSpeed = 10f; 
    [SerializeField] private float _accelerationTime = 1f;
    [SerializeField] private AnimationCurve _fallSpeedCurve;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private bool _isStarted;
    private bool _isFalling;
    private float _accelerationTimer = 0f;

    public event Action BirdStarted;
    public float Speed => _speed;

    private void Start()
    {
        _startPosition = _bird.transform.position;
        _rigidbody2D = _bird.GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _input.OnInputClicked += Move;
    }

    private void OnDisable()
    {
        _input.OnInputClicked -= Move;
    }

    private void Move()
    {        
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
            _bird.transform.rotation = _maxRotation;

            _isFalling = false;

            if (!_isStarted) 
            {
                BirdStarted?.Invoke();

                Debug.Log("invoke");

                _isStarted = true;
            }
    }

    private void Update()
    {
        Debug.Log(_rigidbody2D.velocity.y);
        // Проверяем, начал ли объект падать
        if (!_isFalling && _rigidbody2D.velocity.y < 0)
        {
            _isFalling = true;
            _accelerationTimer = 0f;
        }

        // Если объект падает, увеличиваем скорость падения
        if (_isFalling)
        {
            _accelerationTimer += Time.deltaTime;
            float progress = Mathf.Clamp01(_accelerationTimer / _accelerationTime);
            float curveValue = _fallSpeedCurve.Evaluate(progress); 
            float currentFallSpeed = curveValue * _maxFallSpeed;

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y - currentFallSpeed);
        }

        _bird.transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        _bird.transform.position = _startPosition;
        _rigidbody2D.velocity = new Vector2(0, _tapForce);

        _isStarted = false;
        _isFalling = false;
        _accelerationTimer = 0f;
    }

    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }
}