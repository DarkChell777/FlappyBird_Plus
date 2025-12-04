using System;
using System.Data;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(TimeFetcher))]
[RequireComponent(typeof(Timer))]
public class GiftManager : MonoBehaviour
{
    [SerializeField] private GiftOpener _giftOpener;
    [SerializeField] private TimeFetcher _timeFetcher;
    [SerializeField] private GiftTimeSaver _timeSaver;
    [SerializeField] private Timer _timer;

    private DateTime _nullTime;
    private DateTime _giftOpenTime;  
    private DateTime _nowTime => _timer.NowTime;

    private bool giftAvailable; 
    private bool errorGetTime => _timeFetcher.errorGetTime;
    private bool timerLabelLoad;

    private void OnEnable()
    {
        timerLabelLoad = true;

        LoadGiftTime();

        _timeFetcher.UpdatingNowDate += SetGiftTime;
        _timeFetcher.GetInternetDate();
    }

    private void OnDisable()
    {
        _timeFetcher.UpdatingNowDate -= SetGiftTime;
    }

    private void LoadGiftTime()
    {
        _giftOpenTime = _timeSaver.PutData();
    }

    private void SetGiftTime(DateTime dateTime)
    {
        if (_giftOpenTime == _nullTime)
        {
            //_giftOpenTime = dateTime;          // Отдать подарок при первом входе(через 24 часа)
            //_timeSaver.SetData(_giftOpenTime);

            giftAvailable = true;    // Отдать подарок при первом входе(сразу)
        }

        timerLabelLoad = false;
    } 

    public void TryOpenGift()
    {
        if (giftAvailable)
        {
            _giftOpenTime = _nowTime;  
            _timeSaver.SetData(_giftOpenTime);

            giftAvailable = false;

            _giftOpener.OpenGift();
        }
        else
        {
            Debug.Log("Подарок еще не доступен! Подождите...");
        }
    }

    public void UnlockGift()
    {
        giftAvailable = true;
    }

    public string GetTimeUntilGiftAvailable()
    {
        if (errorGetTime)
        {
            return "Ошибка сети!";
        }
        else if (timerLabelLoad)
        {
            return "Загрузка...";
        }
        else if (giftAvailable)
        {
            return "Подарок доступен!";
        }
        else
        {
            TimeSpan timeUntilAvailable = _giftOpenTime.AddHours(24) - _nowTime;
            CheckAvailableTime(timeUntilAvailable);
            return $"{timeUntilAvailable.Hours}ч {timeUntilAvailable.Minutes}мин {timeUntilAvailable.Seconds}сек";
        }
    }

    private void CheckAvailableTime(TimeSpan timeSpan)
    {
        if (timeSpan.TotalSeconds <= 0)
        {
            giftAvailable = true; 
        }
        else if (timeSpan.TotalHours >= 24 && timeSpan.Seconds > 0)
        {
            if (_giftOpenTime > _nowTime && _nowTime != _nullTime)
            {
                _giftOpenTime = _nowTime; 
                SetGiftTime(_giftOpenTime);
            }
        }
    }

}
