using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ICoin))]
[RequireComponent(typeof(CoinTriggerHandler))]
[RequireComponent(typeof(CoinLeveler))]
public class Coin : MonoBehaviour
{
    [SerializeField] private CoinTriggerHandler _triggerHandler;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private CoinsObjectPool _pool;
    [SerializeField] private DataSaver _coinSaver;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _clip;

    private ICoin _iCoin;

    private void Awake()
    {
        _iCoin = GetComponent<ICoin>();
    }

    private void OnEnable()
    {
        _triggerHandler.CoinCollisioning += OnPuttingCoin;
        CheckMyPosition();
    }

    private void OnDisable()
    {
        _triggerHandler.CoinCollisioning -= OnPuttingCoin;
    }

    private void CheckMyPosition()
    {
        if (_animator.transform.localPosition.y != 0)
        {
            _animator.enabled = false;

            var nowColor = _sprite.color;
            nowColor.a = 255;
            _sprite.color = nowColor;

            _animator.gameObject.transform.localPosition = new Vector3(0,0,0);
        }
    }

    private void OnPuttingCoin(ISecondBirdCollider bird)
    {        
        _coinSaver.OnPuttingCoin();

        _animator.enabled = true;
        _animator.Play(_clip.name);
        StartCoroutine(Waiter());
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(_clip.length);
        
        _pool.PutObject(_iCoin);
    }
}

