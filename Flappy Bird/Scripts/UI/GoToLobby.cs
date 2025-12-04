using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToLobby : MonoBehaviour
{
    [SerializeField] private SceneChangeWindow _changeWindow;
    [SerializeField] private string _sceneName = "Lobby";

    public void ReturnToLobby()
    {
        _changeWindow.DimmingScreen += LoadScene;
        _changeWindow.DimmScreen();
    }

    private void LoadScene()
    {
        _changeWindow.DimmingScreen -= LoadScene;
        
        SceneManager.LoadScene(_sceneName);

        Time.timeScale = 1;
    }
}
