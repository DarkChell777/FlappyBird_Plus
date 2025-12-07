using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimeFetcher _timeFetcher;

    public DateTime NowTime { get; private set; }

    private void OnEnable()
    {
        _timeFetcher.UpdatingNowDate += TimeSetted;
    }

    private void OnDisable()
    {
        _timeFetcher.UpdatingNowDate -= TimeSetted;
    }

    private void TimeSetted(DateTime dateTime)
    {
        NowTime = dateTime;
        StartCoroutine(TimeCounter());
    }

    private IEnumerator TimeCounter()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(1);

            NowTime = NowTime.AddSeconds(1);
        }
    }
}