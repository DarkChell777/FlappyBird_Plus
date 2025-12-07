using UnityEngine;

public class BirdSound : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    [SerializeField] private AudioManager _audioManager;


    private void OnEnable()
    {
        _input.OnInputClicked += Play;
    }

    private void OnDisable()
    {
        _input.OnInputClicked -= Play;
    }

    private void Play()
    {
        _audioManager.PlaySound();
    }
}
