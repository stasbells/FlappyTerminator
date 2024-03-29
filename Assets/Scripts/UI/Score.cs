using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Player _player;
    [SerializeField] private Text _text;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
        _game.GameStartet += Open;
        _game.GameOver += Close;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
        _game.GameStartet -= Open;
        _game.GameOver -= Close;
    }

    private void OnScoreChanged(int scoreCount)
    {
        _text.text = scoreCount.ToString();
    }

    private void Open()
    {
        _canvasGroup.alpha = 1f;
    }

    private void Close()
    {
        _canvasGroup.alpha = 0f;
    }
}