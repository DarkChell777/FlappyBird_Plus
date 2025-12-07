using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GiftOpeningProcess : MonoBehaviour
{
    [SerializeField] private GiftOpenAnimator _openAnimation;
    [SerializeField] private VolumeController _soundController;
    [SerializeField] private AudioClip _fallClip;
    [SerializeField] private AudioClip _openClip;
    [SerializeField] private CanvasGroup _window;
    [SerializeField] private CanvasGroup _gift;
    [SerializeField] private CanvasGroup _prize;
    [SerializeField] private CanvasGroup _getButton;

    [Header("Animations")]
    [SerializeField] private Animator _giftAnimator;
    [SerializeField] private AnimationClip _giftClip;
    [SerializeField] private Animator _prizeAnimator;
    [SerializeField] private AnimationClip _prizeClip;
    [SerializeField] private Animator _buttonAnimator;
    [SerializeField] private AnimationClip _buttonClip;

    private void Awake()
    {
        _getButton.GetComponent<Button>().onClick.AddListener(GettingPrize);
    }

    public void Open()
    {
        _window.alpha = 1.0f;
        _window.blocksRaycasts = true;

        StartCoroutine(OpenGiftSequence());
    }

    private IEnumerator OpenGiftSequence()
    {
        yield return new WaitForSeconds(0.3f);
        ChestFalling();

        yield return new WaitForSeconds(_giftClip.length);
        ChestOpening();

        yield return new WaitForSeconds(_openAnimation.AnimTime);
        PrizeAppearance();

        yield return new WaitForSeconds(_prizeClip.length);
        GetPrizeButtonAppearance();

        yield return new WaitForSeconds(_buttonClip.length);
        _buttonAnimator.enabled = false;
        _getButton.alpha = 1.0f;
        _getButton.blocksRaycasts = true;
    }

    private void ChestFalling()
    {
        _giftAnimator.Play(_giftClip.name);
        _soundController.SetSound(_fallClip);
        _soundController.PlaySound();
    }

    private void ChestOpening()
    {
        _giftAnimator.enabled = false;
        _gift.alpha = 1.0f;
        
        _openAnimation.Open();

        _soundController.SetSound(_openClip);
        _soundController.PlaySound();
    }

    private void PrizeAppearance()
    {
        _prizeAnimator.Play(_prizeClip.name);
    }

    private void GetPrizeButtonAppearance()
    {
        _prizeAnimator.enabled = false;
        _prize.alpha = 1;

        _buttonAnimator.Play(_buttonClip.name);
    }

    private void GettingPrize()
    {
        Reset();
    }

    private void Reset()
    {
        _window.alpha = 0;
        _window.blocksRaycasts = false;

        _prize.alpha = 0;
        _prizeAnimator.enabled = true;

        _getButton.alpha = 0;
        _getButton.blocksRaycasts = false;
        _buttonAnimator.enabled = true;

        _gift.alpha = 0;
        _giftAnimator.enabled = true;

        _openAnimation.Reset();
        _soundController.ResetSound();
    }
}
