using System.Collections;
using TMPro;
using UnityEngine;

public class TimerUpdater : MonoBehaviour
{
    public GiftManager giftManager;
    public TextMeshProUGUI timerText;

    private void OnEnable()
    {
        StartCoroutine(TimeUpdater());
    }

    private IEnumerator TimeUpdater()
    {
        while (enabled)
        {
            timerText.text = giftManager.GetTimeUntilGiftAvailable();
            yield return new WaitForSeconds(0.4f);
        }
    }
}
