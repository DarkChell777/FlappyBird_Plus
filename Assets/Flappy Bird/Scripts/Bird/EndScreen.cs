using System;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        EndWindow.SetActive(false);
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        EndWindow.SetActive(true);
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
