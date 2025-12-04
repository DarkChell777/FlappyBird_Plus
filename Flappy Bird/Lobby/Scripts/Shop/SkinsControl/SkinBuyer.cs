using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkinBuyer : MonoBehaviour
{
    [SerializeField] protected ConfigsController _controller;
    [SerializeField] protected TextMeshProUGUI _balanceValue;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected AnimationClip _clip;
    [SerializeField] protected Button _buyButton;
    
    protected Color _redColor = Color.red;
    protected Color _standartColor;

    protected float _animEnter = 0.2f;
    protected float _animExit = 0.7f;


    protected virtual void Start()
    {
        _standartColor = _balanceValue.color;

        UpdateBalance();

        _buyButton.onClick.AddListener(OnBuy);
    }

    protected virtual void OnEnable() {UpdateBalance();}

    public abstract void OnBuy();
    
    protected abstract void CanBuy();

    protected abstract void CantBuy();

    protected abstract void UpdateBalance();
    
    protected abstract IEnumerator ChangeColor();
    
}
