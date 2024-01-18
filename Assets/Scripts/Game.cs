using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Score _score;

    public event UnityAction GameStartet;
    public event UnityAction GameOver;
    public event UnityAction GameRestarted;

    private void OnEnable()
    {
        _startScreen.StartButtonClick += OnStartButtonClick;
        _menuScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.StartButtonClick -= OnStartButtonClick;
        _menuScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        _startScreen.Open();
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        _menuScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _menuScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        _player.ResetPlayer();
        _player.ActivePlayer();
        GameStartet?.Invoke();
    }

    public void OnGameOver()
    { 
        _gameOverScreen.Open();
        GameOver?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _menuScreen.Open();
        GameRestarted?.Invoke();
    }
}
