using System;
using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    
    public event Action OnContinueGame;

    public void OnContinue()
    {
        _pauseWindow.SetActive(false);
        OnContinueGame?.Invoke();
    }

}
