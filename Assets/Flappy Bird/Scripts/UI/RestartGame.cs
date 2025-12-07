using System;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;

    public event Action OnRestartGame;

    public void OnRestart()
    {
        _pauseWindow.SetActive(false);
        OnRestartGame?.Invoke();
    }
}
