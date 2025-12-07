using System.Collections;
using UnityEngine;

public class BackgroundBuyerControl : SkinBuyer
{
    [SerializeField] private BackgroundSkinChanger _changer;
    [SerializeField] private BackgroundSkinManager _manager;
    [SerializeField] private BackgroundSkins _backgroundSkins;

    protected int _currentSkin => _manager.SkinIndex;
    private int _balance => _controller.Balance;

    public override void OnBuy()
    {
        if (_balance < _backgroundSkins.Backgrounds[_currentSkin].price)
        {
            CantBuy();
        }
        else
        {
            CanBuy();
        }
    }

    protected override void CanBuy()
    {
        _controller.UnlockBSkin(_backgroundSkins.Backgrounds[_currentSkin].skin);
        _controller.SetBalance(_balance - _backgroundSkins.Backgrounds[_currentSkin].price);
        _controller.SaveConfigs();

        _manager.UpdateSkin();
        UpdateBalance();
    }

    protected override void CantBuy()
    {
        _animator.Play(_clip.name);
        StartCoroutine(ChangeColor());
    }

    protected override void UpdateBalance()
    {
        _balanceValue.text = _balance.ToString();
    }

    protected override IEnumerator ChangeColor()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _animEnter)
        {
            _balanceValue.color = Color.Lerp(_standartColor, _redColor, elapsedTime / _animEnter);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _balanceValue.color = _redColor; 
        elapsedTime = 0f;

        while (elapsedTime < _animExit)
        {
            _balanceValue.color = Color.Lerp(_redColor, _standartColor, elapsedTime / _animExit);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _balanceValue.color = _standartColor; 
    }
}
