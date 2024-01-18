using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _milisecondsBetweenShoot;

    private Player _player;
    private Shooter _shooter;

    private void Start()
    {
        _player = FindFirstObjectByType<Player>();
        _shooter = GetComponent<Shooter>();       
        OnSoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBall fireBall))
        {
            gameObject.SetActive(false);
            _player.IncreaseScore();
        }
    }

    private async void OnSoot()
    {
        while (gameObject != null)
        {
            if (gameObject.activeSelf)
                _shooter.Shoot();

            await Task.Delay(_milisecondsBetweenShoot);
        }
    }
}