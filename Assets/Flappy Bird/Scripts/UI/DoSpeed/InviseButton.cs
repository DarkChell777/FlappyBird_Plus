using UnityEngine;
using System.Collections;

public class InviseButton : MonoBehaviour 
{
    [SerializeField] private Game _game;
    [SerializeField] private CanvasGroup _button;
    [SerializeField] private float _delayBeforeInvise;
    [SerializeField] private float _delayBlink = 0.5f;

    private bool _buttonClicked;

    private void Start()
    {
        StartInvise();
    }

    private void OnEnable()
    {
        _game.GameRestart += StartInvise;
    }

    private void OnDisable()
    {
        _game.GameRestart -= StartInvise;
    }

    public void HideButton()
    {
        StopAllCoroutines();

        _buttonClicked = true;

        _button.alpha = 0; 
        _button.interactable = false;  
        _button.blocksRaycasts = false; 
    }

    private void StartInvise()
    {
        if (_buttonClicked) 
        {
            _buttonClicked = false;
            return;
        }
        
        StartCoroutine(InviseProces());
    }

    private IEnumerator InviseProces()
    {
        _button.alpha = 1;
        _button.interactable = true;
        _button.blocksRaycasts = true;

        yield return new WaitForSeconds(_delayBeforeInvise);

        int count = 0;
        while (count < 3)
        {
            yield return StartCoroutine(FadeButton(0.6f));
            yield return new WaitForSeconds(_delayBlink);
            yield return StartCoroutine(FadeButton(1f));
            yield return new WaitForSeconds(_delayBlink);
            count++;
        }

        yield return StartCoroutine(FadeButton(0f));
        _button.interactable = false;
        _button.blocksRaycasts = false;
    }

    private IEnumerator FadeButton(float targetAlpha)
    {
        float startAlpha = _button.alpha;
        float duration = 0.5f; 
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            _button.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            yield return null;
        }

        _button.alpha = targetAlpha; 
    }
}
