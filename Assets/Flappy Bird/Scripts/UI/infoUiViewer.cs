using TMPro;
using UnityEngine;

public class infoUiViewer : MonoBehaviour
{
    [SerializeField] private DataSaver _data;
    [SerializeField] private Game _game;
    [SerializeField] private TextMeshProUGUI _balanceValue;
    [SerializeField] private TextMeshProUGUI _beastScoreValue;

    private float _outTime = 0.5f;

    private void Start()
    {
        UpdateScore();
    }

    private void OnEnable()
    {
        _game.GameRestart += UpdateScore;
        UpdateBalance();
        UpdateScore();
    }

    private void OnDisable()
    {
        _game.GameRestart -= UpdateScore;
    }

    private void FixedUpdate()
    {
        if (_outTime <= 0)
        {
            _outTime = 0.5f;
            UpdateBalance();
        }

        _outTime -= Time.deltaTime;
    }

    private void UpdateBalance()
    {
        _balanceValue.text = _data.Balance.ToString();
    }

    private void UpdateScore()
    {
        _beastScoreValue.text = _data.BeastScore.ToString();
    }
}
