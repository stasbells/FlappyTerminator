 using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Enemy _enemy;

    public bool IsPointFree { get; private set; }

    private void Awake()
    {
        IsPointFree = true;
    }

    private void Update()
    {
        if(_enemy != null && _enemy.gameObject.activeSelf == false)
            IsPointFree = true;       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            IsPointFree = false;
            _enemy = enemy;
        }
    }
}