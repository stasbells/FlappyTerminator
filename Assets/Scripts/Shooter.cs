using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private FireBall _fireBall;
    [SerializeField] private Transform _shootPoint;

    public void Shoot()
    {
        Instantiate(_fireBall, _shootPoint.position, transform.rotation);
    }
}