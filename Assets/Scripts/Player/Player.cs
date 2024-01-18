using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent (typeof(Shooter))]
public class Player : MonoBehaviour
{
    [SerializeField] private Game _game;

    private PlayerMover _mover;
    private Shooter _shooter;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void OnEnable()
    {
        _game.GameRestarted += ResetPlayer;
    }

    private void OnDisable()
    {
        _game.GameRestarted -= ResetPlayer;
    }

    private void Start()
    {    
        _mover = GetComponent<PlayerMover>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _shooter.Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FireBall fireBall))
            Die();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetPlayer();
    }

    public void ActivePlayer() 
    {
        _mover.ActiveMover(true);
    }

    public void Die()
    {
        GameOver?.Invoke();
        _mover.ActiveMover(false);
        gameObject.SetActive(false);
    }
}
