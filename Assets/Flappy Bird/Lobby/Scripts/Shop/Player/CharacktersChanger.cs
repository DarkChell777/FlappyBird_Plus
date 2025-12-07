using UnityEngine.UI;
using UnityEngine;

public class CharacktersChanger : MonoBehaviour 
{
    [SerializeField] private PlayerSkinManager _manager;
    [SerializeField] private Sprite[] _values;
    [SerializeField] private Image _characterHealth;
    [SerializeField] private Image _characterDamage;
    [SerializeField] private Image _characterMobility;

    private PlayerSkin[] _skins => _manager.PlayerSkins.Characters;

    private void OnEnable() { _manager.SkinChanging += ChangeCharackters;}

    private void OnDisable() { _manager.SkinChanging -= ChangeCharackters;}

    public void ChangeCharackters(int index)
    {
        PlayerCharactiristiks _characktiristiks = _skins[index].charactiristiks;

        _characterHealth.sprite = _values[_characktiristiks.health];
        _characterDamage.sprite = _values[_characktiristiks.damage];
        _characterMobility.sprite = _values[_characktiristiks.mobility];
    }
}