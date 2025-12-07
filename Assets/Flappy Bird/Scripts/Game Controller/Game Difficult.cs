using System;
using TMPro;
using UnityEngine;

public class GameDifficult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Game _gameMessages;
    [SerializeField] private DifficultSeter _seter;
    [SerializeField] private DifficultHandler _handler;

    private DifficultsType _currentDifficult;
    public DifficultsType CurrentDifficult => _currentDifficult;
    public Difficults Difficult {get; private set;}
    public event Action<Difficults> DifficultChanged;


    private void OnEnable()
    {
        _seter.DifficultSetting += SetDifficult;
    }

    private void OnDisable()
    {
        _seter.DifficultSetting -= SetDifficult;
    }

    private void SetDifficult(int difficult)
    {
        if (difficult == 0)
        {
            Difficult = _handler.AllDifficults[0];
            DifficultChanged?.Invoke(Difficult);
        }

        else if (difficult == 1) 
        {
            _currentDifficult = DifficultsType.Normal;
            Difficult = _handler.AllDifficults[1];
            DifficultChanged?.Invoke(Difficult);
        }

        else if (difficult == 2) 
        {
            _currentDifficult = DifficultsType.Hard;
            Difficult = _handler.AllDifficults[2];
            DifficultChanged?.Invoke(Difficult);
        }

        else if (difficult != 0) Debug.LogError("Неизвестная сложность: " + difficult);
    }
}


