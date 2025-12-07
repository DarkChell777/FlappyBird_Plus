using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private PauseGame _pause;
    [SerializeField] private ContinueGame _continue;
    [SerializeField] private RestartGame _restart;
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private CoinsObjectPool _coinsObjectPool;

    public event Action GameRestart;

    
    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
        _endScreen.RestartButtonClicked += OnRestart;
        _pause.OnPauseGame += OnPause;
        _continue.OnContinueGame += OnContinue;
        _restart.OnRestartGame += OnRestart;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
        _endScreen.RestartButtonClicked -= OnRestart;
        _pause.OnPauseGame -= OnPause;
        _continue.OnContinueGame -= OnContinue;
        _restart.OnRestartGame -= OnRestart;
    }

    private void OnGameOver()
    {
        Debug.Log("Game Over!");
        _endScreen.Open();
        Time.timeScale = 0;
    }

    private void OnPause()
    {
        Time.timeScale = 0;
    }

    private void OnContinue()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        OnRestart();
    }

    private void OnRestart()
    {
        _endScreen.Close();
        GameRestart?.Invoke();
        StartGame();
    }

    private void StartGame()
    {
        _score.Reset();
        Time.timeScale = 1;
        _bird.Reset();
        _objectPool.ReturnAllObjectsToPool();
        _coinsObjectPool.ReturnAllObjectsToPool();
    }
}
