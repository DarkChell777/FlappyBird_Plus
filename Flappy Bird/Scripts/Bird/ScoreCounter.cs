using UnityEngine;
using TMPro;
using System;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private int _pointsInRange = 1;

    private float _outTime = 0.25f;
    private int _scoreValue = 0;

    public event Action<int> ScoreChanging;


    private void Update()
    {
        if (_outTime <= 0)
        {
            _outTime = 0.25f;
            _scoreValue += _pointsInRange;

            _score.SetText(_scoreValue.ToString("F0"));

            ScoreChanging?.Invoke(_scoreValue);
        }

        _outTime -= Time.deltaTime;
    }

    public int GetScoreValue()
    {
        int scoreValue = int.Parse(_score.text);
        return scoreValue;
    }

    public void Reset()
    {
        _scoreValue = 0;
        _score.SetText("0");
    }

}
