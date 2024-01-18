using UnityEngine;
using UnityEngine.Events;

public class StartScreen : Screen
{
    public event UnityAction StartButtonClick;

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
    }

    protected override void OnButtonClick()
    {
        StartButtonClick?.Invoke();
    }
}