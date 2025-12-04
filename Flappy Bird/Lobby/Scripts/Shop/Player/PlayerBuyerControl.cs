using System.Collections;
using UnityEngine;

public class PlayerBuyerControl : SkinBuyer
{
    [SerializeField] private PlayerSkinChanger _changer;
    [SerializeField] private PlayerSkinManager _manager;
    [SerializeField] private PlayerSkins _playerSkins;
    
    private int _currentSkin => _manager.SkinIndex;
    private int _balance => _controller.Balance;

    public override void OnBuy()
    {
        if (_balance < _playerSkins.Characters[_currentSkin].price)
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
        _controller.UnlockPSkin(_playerSkins.Characters[_currentSkin].skin);
        _controller.SetBalance(_balance - _playerSkins.Characters[_currentSkin].price);
        _controller.SaveConfigs();

        _manager.UpdateSkin();
        UpdateBalance();
    }

    protected override void CantBuy()
    {
        _animator.Play(_clip.name);
        StartCoroutine(ChangeColor());
    }

    public void UpdatingBalance()
    {
        UpdateBalance();
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
