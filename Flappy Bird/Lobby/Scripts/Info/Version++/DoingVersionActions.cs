using UnityEngine;

public class DoingVersionActions : MonoBehaviour 
{
    [SerializeField] private ConfigsController _controller;
    [SerializeField] private VersionBinarySaver _versionSaver;
    [SerializeField] private GiftManager _giftManager;
    [SerializeField] private GameObject[] _modes;


    public void UnlockVersion()
    {
        _versionSaver.SaveData();

        foreach (var mode in _modes)
        {
            mode.gameObject.SetActive(true);
        }
    }

    public void GivingMoney()
    {
        if (_controller.Balance < 999) _controller.SetBalance(999);

        _controller.SaveConfigs();
    }

    public void Giving20Money()
    {
        _controller.SetBalance(_controller.Balance + 20);

        if (_controller.Balance > 999) _controller.SetBalance(999);

        _controller.SaveConfigs();
    }

    public void UnlockGift()
    {
        _giftManager.UnlockGift();
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        _controller.DeleteData();
        Application.Quit();
    }
}

