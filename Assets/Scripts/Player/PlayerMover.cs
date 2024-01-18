using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidBody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private bool _isActive;
    private Vector2 _mass = new Vector2(0, 0);

    private void Start()
    {
        _isActive = false;
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.centerOfMass = _mass;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        ResetPlayer();
    }

    private void Update()
    {
        if (_isActive)
            Move();
        else
            _rigidBody.simulated = false;
    }

    public void ResetPlayer()
    {
       gameObject.SetActive(true);
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidBody.velocity = Vector2.zero;
    }

    public void ActiveMover(bool isActive)
    {
        _isActive = isActive;
    }

    private void Move()
    {
        _rigidBody.simulated = true;

        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = _maxRotation;
            _rigidBody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}