using System;
using UnityEngine;

public class GiftTimeSaver : MonoBehaviour
{
    [SerializeField] private BinarySaver _saver;
    [SerializeField] private ConfigsController _controller;

    public void SetData(DateTime nowTime)
    {
        _saver.SetGiftOpenedTime(nowTime);
        _controller.SaveConfigs();
    }

    public DateTime PutData()
    {
        return _saver.PutGiftOpenedTime();
    }
}
