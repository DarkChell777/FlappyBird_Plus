using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GiftOpenAnimator : MonoBehaviour
{
    [SerializeField] private Image _gift;
    [SerializeField] private float _animTime = 1f;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _clip;

    public float AnimTime => _animTime;

    public void Open()
    {
        StartCoroutine(OpenAnim());
    }

    private IEnumerator OpenAnim()
    {
        foreach (var frame in _sprites)
        {
            _gift.sprite = frame;
            yield return new WaitForSeconds(AnimTime / _sprites.Length);
        }

        _animator.Play(_clip.name);
    }

    public void Reset()
    {
        _gift.sprite = _sprites[0];
    }
}
