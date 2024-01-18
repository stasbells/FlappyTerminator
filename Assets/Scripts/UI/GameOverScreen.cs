using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen 
{
    [SerializeField] private ScoreBoard _scoreBoard;

    private readonly int ScoreBoard = Animator.StringToHash(nameof(ScoreBoard));

    private Animator _animator;

    public event UnityAction RestartButtonClick;

    private void Start()
    {
        _animator = _scoreBoard.GetComponent<Animator>();
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0f;
        Button.interactable = false;
        Button.image.raycastTarget = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1f;
        Button.interactable = true;
        Button.image.raycastTarget = true;
        _animator.Play(ScoreBoard);
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}