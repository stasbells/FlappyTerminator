using UnityEngine;

[RequireComponent(typeof(Player))]
public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _topPoint;
    [SerializeField] private Transform _lowPoint;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_player.transform.position.y > _topPoint.position.y)
            _player.transform.position = _lowPoint.position;

        if (_player.transform.position.y < _lowPoint.position.y)
            _player.transform.position = _topPoint.position;
    }
}