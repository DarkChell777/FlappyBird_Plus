using System;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;

    public event Action OnPauseGame;

    public void OnPause()
    {
        _pauseWindow.SetActive(true);
        OnPauseGame?.Invoke();
    }
}
