using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ConfigsController : MonoBehaviour
{
    [SerializeField] private BinarySaver _binarySaver;
    [SerializeField] private PlayerSkins _charackters;
    [SerializeField] private PlayerBuyerControl _buyerControl;
    [SerializeField] private BackgroundSkins _backgrounds;

    public int Balance {get; private set;}
    private int _beastScore;
    private PlayerSkin[] _playerSkins => _charackters.Characters;
    private BackgroundSkin[] _backgroundSkins => _backgrounds.Backgrounds;
    private Dictionary<PlayerSkinType, bool> _PSkinsList = new Dictionary<PlayerSkinType, bool>();
    private Dictionary<BackgroundSkinType, bool> _BSkinsList = new Dictionary<BackgroundSkinType, bool>();
    

    private void Awake()
    {
        LoadConfigs();
    }

    private void LoadConfigs()
    {
        BinarySaver.PlayerData loadedData = _binarySaver.LoadData();

        if (loadedData != null)
        {
            Debug.Log($"Баланс монет: {loadedData.Balance}");
            Debug.Log($"Рекорд: {loadedData.beastScore}");
            
            _PSkinsList = loadedData.acquiredPlayerSkins;
            _BSkinsList = loadedData.acquiredBackgroundSkins;

            if (_PSkinsList.Count != _playerSkins.Length) CorrectPlayerSkins();
            
            if (_BSkinsList.Count != _backgroundSkins.Length) CorrectBackgroundSkins();
            

            Balance = loadedData.Balance;
            _beastScore = loadedData.beastScore;
        }

        else
        {
            FillPlayerLists();
            FillBackgroundLists();

            Balance = 0;
            _beastScore = 0;

            Debug.Log("BinarySaver не найден!");
        }
        _PSkinsList[PlayerSkinType.Golub] = true;
        _BSkinsList[BackgroundSkinType.Zamok] = true;
    }

    private void FillPlayerLists()
    {
        _PSkinsList.Clear();

        foreach (var skin in _playerSkins)
        {
            PlayerSkinType key = skin.skin;

            _PSkinsList.Add(key , false);
        };
    }

    private void FillBackgroundLists()
    {
        _BSkinsList.Clear();

        foreach (var skin in _backgroundSkins)
        {
            BackgroundSkinType key = skin.skin;

            _BSkinsList.Add(key , false);
        };
    }

    private void CorrectPlayerSkins()
    {
        List<PlayerSkinType> hasSkins = new List<PlayerSkinType>();

        foreach (var skin in _playerSkins)
        {
            PlayerSkinType key = skin.skin;

            if (_PSkinsList[key]) 
            {
                hasSkins.Add(key);
            }
        }

        FillPlayerLists();

        foreach (var skin in hasSkins)
        {
            _PSkinsList[skin] = true;
        }
    }

    private void CorrectBackgroundSkins()
    {
        List<BackgroundSkinType> hasSkins = new List<BackgroundSkinType>();

        foreach (var skin in _backgroundSkins)
        {
            BackgroundSkinType key = skin.skin;

            if (_BSkinsList[key]) 
            {
                hasSkins.Add(key);
            }
        }

        FillBackgroundLists();

        foreach (var skin in hasSkins)
        {
            _BSkinsList[skin] = true;
        }
    }

    public void SaveConfigs()
    {
        _binarySaver.SaveData(Balance, _beastScore, _PSkinsList, _BSkinsList);
    }

    public void UnlockPSkin(PlayerSkinType skin)
    {
        _PSkinsList[skin] = true;
    }

    public void UnlockBSkin(BackgroundSkinType skin)
    {
        _BSkinsList[skin] = true;
    }

    public void SetBalance(int value)
    {
        if ((value <= 0) ||(1000 <= value)) return;

        Balance = value;

        _buyerControl.UpdatingBalance();
    }

    public void AddBalance(int value)
    {
        if (value <= 0 && Balance + value >= 1000) return;

        StartCoroutine(MoneyCounting(Balance, Balance + value));
    }

    private IEnumerator MoneyCounting(int firstBalance, int targetBalance)
    {
    yield return new WaitForSeconds(2f); 

    float duration = 1.0f; 
    float elapsed = 0f; 
    int newBalance = firstBalance; 

    while (elapsed < duration)
    {
        elapsed += Time.deltaTime; 
        float t = Mathf.Clamp01(elapsed / duration); 

        newBalance = (int)Mathf.Lerp(firstBalance, targetBalance, t);
        Balance = newBalance;
        _buyerControl.UpdatingBalance();
        
        yield return null; 
    }
    Balance = targetBalance;
    _buyerControl.UpdatingBalance();
    }

    public void SetScore(int value)
    {
        if ((0 <= value) ||(value <= 1000000)) return;

        _beastScore = value;
    }

    public bool IsPSkinUnlocked(PlayerSkinType skin)
    {
        return _PSkinsList[skin];
    }

    public bool IsBSkinUnlocked(BackgroundSkinType skin)
    {
        return _BSkinsList[skin];
    }

    public void DeleteData()
    {
        Debug.Log("Deleted Data!");
        _binarySaver.DeleteData();

        LoadConfigs();
    }
}
