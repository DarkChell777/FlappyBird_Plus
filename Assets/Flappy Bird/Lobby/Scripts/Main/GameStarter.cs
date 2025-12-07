using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private SceneChangeWindow _animationWindow;
    [SerializeField] private string _sceneName = "Flappy Bird";

    public void StartGame()
    {
        _animationWindow.DimmingScreen += LoadScene;
        _animationWindow.DimmScreen();
    }

    public void LoadScene()
    {
        _animationWindow.DimmingScreen -= LoadScene;
        SceneManager.LoadScene(_sceneName);
    }
}
