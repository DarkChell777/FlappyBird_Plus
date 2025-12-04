using System.Collections;
using UnityEngine;

public class SpeedChanging : MonoBehaviour
{
    [SerializeField] private BirdMover _birdHandler;
    [SerializeField] private Game _game;
    [SerializeField] private GameDifficult _gameDifficult;

    private float _birdCurrentSpeed => _birdHandler.Speed;
    private float _standartSpeed;
    private float _currentSpeed;

    private void Awake()
    {
        _standartSpeed = _birdHandler.Speed;
    }

    private void OnEnable()
    {
        _game.GameRestart += Reset;
        _gameDifficult.DifficultChanged += SetDifficult;
    }

    private void OnDisable()
    {
        _game.GameRestart -= Reset;
        _gameDifficult.DifficultChanged -= SetDifficult;
    }

    private void SetDifficult(Difficults difficult)
    {
        if (difficult.type == DifficultsType.Normal)
        {
            StartEnumerator(difficult.pointsSpeedInSecond);
        }

        if (difficult.type == DifficultsType.Hard)
        {
            StartEnumerator(difficult.pointsSpeedInSecond);
        }
    }

    private void StartEnumerator(float speedPoints)
    {
        StartCoroutine(ChangingSpeed(speedPoints));
    }

    private IEnumerator ChangingSpeed(float speedPoints)
    {
        _currentSpeed = _birdCurrentSpeed;

        while (enabled)
        {
            _currentSpeed += speedPoints;
            _birdHandler.ChangeSpeed(_currentSpeed);

            yield return new WaitForSeconds(1);  
        }
    }

    public void SetSpeed(float speed)
    {
        if (0 < speed && speed < 150)
        {
            _currentSpeed = speed;
        }
    }

    private void Reset()
    {
        _birdHandler.ChangeSpeed(_standartSpeed);
        _currentSpeed = _standartSpeed;
    }

}
