using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizeManager : MonoBehaviour 
{
    [SerializeField] private PlayerSkins _playerSkins;
    [SerializeField] private BackgroundSkins _backgroundSkins;
    [SerializeField] private ConfigsController _controller;
    [SerializeField] private Image _prizeIcon;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Sprite _moneySprite;

    public void SetPrize(int money)
    {

        _controller.AddBalance(money);

        _prizeIcon.sprite = _moneySprite;
        _text.text = "х" + money.ToString();
    }

    public void SetPrize(object selectedSkin)
    {

        if (selectedSkin is PlayerSkin)
        {
            PlayerSkin playerSkin = (PlayerSkin)selectedSkin;

            _controller.UnlockPSkin(playerSkin.skin);

            _prizeIcon.sprite = playerSkin.sprite;
            _text.text = playerSkin.About;
        }
        else if (selectedSkin is BackgroundSkin)
        {
            BackgroundSkin backgroundSkin = (BackgroundSkin)selectedSkin;

            _controller.UnlockBSkin(backgroundSkin.skin);

            _prizeIcon.sprite = backgroundSkin.shopSprite;
            _text.text = backgroundSkin.About;
        }
        else
        {
            Debug.LogError("Prize is of unknown type.");
        }

        _controller.SaveConfigs();
    }
}