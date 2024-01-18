using UnityEngine;
using UnityEngine.Events;

public class MenuScreen : Screen
{
    public event UnityAction PlayButtonClick;

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
        PlayButtonClick?.Invoke();
    }
}
