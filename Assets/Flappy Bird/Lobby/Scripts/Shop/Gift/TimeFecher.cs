using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class TimeFetcher : MonoBehaviour
{
    private string url = ""; // TODO: Add url from file
    private int tryConnect;

    public bool errorGetTime { get; private set; }
    public event Action<DateTime> UpdatingNowDate;

    public void GetInternetDate()
    {
        StartCoroutine(GetTime());
    }

    private IEnumerator GetTime()
{
    while (enabled)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (tryConnect >= 3) 
            {
                errorGetTime = true;
                break;
            }

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Ошибка: " + webRequest.error);
                tryConnect++;

                yield return new WaitForSeconds(1);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;

                ParseAndConvert(jsonResponse);

                break;
            }
        }
    }
}


    private void ParseAndConvert(string json)
    {
        var jsonObject = JsonUtility.FromJson<TimeZoneResponse>(json);
        
        DateTime dateTime;

        if (DateTime.TryParse(jsonObject.formatted, out dateTime)) UpdatingNowDate?.Invoke(dateTime);

        else errorGetTime = true;

        Debug.Log("Текущая дата и время в Москве: " + dateTime);
    }

    [Serializable]
    public class TimeZoneResponse
    {
        public string formatted;
    }
}
