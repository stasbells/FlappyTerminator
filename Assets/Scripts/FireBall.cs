using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyDistance;
    [SerializeField] private Vector2 _direction;

    private Player _player;
    private Vector2 _angle;

    private void Awake()
    {
        _player = FindFirstObjectByType<Player>();
        _angle = new Vector2(0, transform.rotation.z);
    }

    private void Update()
    {
        if (_player == null)
            Destroy(gameObject);
           
        transform.Translate((_direction + _angle) * _speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, _player.transform.position) > _destroyDistance)
            Destroy(gameObject);
    }
}