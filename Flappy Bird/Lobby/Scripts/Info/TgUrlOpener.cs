using UnityEngine;

public class TgUrlOpener : MonoBehaviour
{
    [SerializeField] private string _url;

    public void OpenUrl()
    {
        Application.OpenURL(_url);
    }
}
