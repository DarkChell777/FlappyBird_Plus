using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private BinarySaver _binarySaver;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Game _game;
    [SerializeField] private GoToLobby _lobby;
    [SerializeField, Min(1)] private int _periodicitySave = 20;

    private int _balance;
    private int _beastScore;
    private Dictionary<PlayerSkinType, bool> _PSkinsList = new Dictionary<PlayerSkinType, bool>();
    private Dictionary<BackgroundSkinType, bool> _BSkinsList = new Dictionary<BackgroundSkinType, bool>();

    public int Balance => _balance;
    public int BeastScore => _beastScore;

    private void Awake()
    {
        LoadData();
    }

    private void OnEnable()
    {
        _game.GameRestart += SaveData;
        _scoreCounter. ScoreChanging += SetScore;
        StartCoroutine(SaverWithRange());
    }

    private void OnDisable()
    {
        _game.GameRestart -= SaveData;
        _scoreCounter.ScoreChanging -= SetScore;
    }

    private void LoadData()
    {
        BinarySaver.PlayerData loadedData = _binarySaver.LoadData();

        if (loadedData != null)
        {
            _balance = loadedData.Balance;
            _beastScore = loadedData.beastScore;

            _PSkinsList = loadedData.acquiredPlayerSkins;
            _BSkinsList = loadedData.acquiredBackgroundSkins;


        }

        else
        {
            _lobby.ReturnToLobby();

            Debug.Log("Файл с данными не найден");
        }
    }

    // Add to ui buttons(2) lisener
    public void SaveData()
    {
        Debug.Log(_beastScore);
        Debug.Log(_balance);
        _binarySaver.SaveData(_balance, _beastScore, _PSkinsList, _BSkinsList);
    }

    public void OnPuttingCoin()
    {
        _balance ++;
        CorrectBalance();
    }

    public void SetScore(int value)
    {
        if ((value < 0) || (1000000 <= value)) _beastScore = 0;

        if (_beastScore < value) _beastScore = value;
    }

    public void SetBalance(int value)
    {
        _balance = value;

        CorrectBalance();
    }

    private void CorrectBalance()
    {
        if (_balance < 0) _balance = 0;
        
        else if (10000 <= _balance) _balance = 9999;
    }

    private IEnumerator SaverWithRange()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_periodicitySave);

            SaveData();
        }
    }
}
