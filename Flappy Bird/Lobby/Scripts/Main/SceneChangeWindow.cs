using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeWindow : MonoBehaviour
{
    [SerializeField] private Image _window;
    [SerializeField] private float _elapsedTime = 0.7f;

    public event Action DimmingScreen;
    public event Action LightingScreen;

    private Color _standartColor = Color.black;

    private void Awake()
    {
        _standartColor.a = 0;
        _window.color = Color.black;
    }

    private void Start()
    {
        LightScreen();
    }

    public void DimmScreen()
    {
        StartCoroutine(DimmingScreenAnimation());
    }

    public void LightScreen()
    {
        StartCoroutine(LightingScreenAnimation());
    }

    private IEnumerator DimmingScreenAnimation()
    {
        _window.raycastTarget = true;

        float outTime = 0;

        while (outTime <= _elapsedTime)
        {
            _window.color = Color.Lerp(_standartColor, Color.black, outTime / _elapsedTime);
            outTime += Time.unscaledDeltaTime;
            yield return null;
        }

        _window.color = Color.black;

        DimmingScreen?.Invoke();
    }

    private IEnumerator LightingScreenAnimation()
    {
        _window.raycastTarget = false;

        float outTime = 0;

        while (outTime <= _elapsedTime)
        {
            _window.color = Color.Lerp(Color.black, _standartColor, outTime / _elapsedTime);
            outTime += Time.unscaledDeltaTime;
            yield return null;
        }

        _window.color = _standartColor;

        LightingScreen?.Invoke();
    }
}
