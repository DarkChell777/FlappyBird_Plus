using UnityEngine;

public class PlayerSkinChecker : SkinsChecker
{
    [SerializeField] private PlayerSkinManager _manager;
    [SerializeField] private PlayerSkinChanger _changer;
    [SerializeField] private PlayerSkins _skins;

    private PlayerSkin _skin;

    protected override void OnEnable() {_manager.SkinChanging += CheckSkin;}
    protected override void OnDisable() {_manager.SkinChanging -= CheckSkin;}

    public override void CheckSkin(int index)
    {
        _skin = _skins.Characters[index];

        bool isUnlock = _manager.IsUnlock(index);

        if (isUnlock)
        {
            SkinIsUnlock(index);
        }

        else
        {
            SkinIsntUnlock();
        }

        
    }

    private void SkinIsUnlock(int index)
    {
        bool isSelected = _manager.IsSelectedSkin(index);

        _notAvialable.gameObject.SetActive(false);
        _lock.gameObject.SetActive(false);
        _buyButton.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(true);

        if (isSelected) _selectButton.interactable = false;

        else _selectButton.interactable = true;
    }

    private void SkinIsntUnlock()
    {
        _selectButton.gameObject.SetActive(false);

        if (_skin.dontSale)
        {
            _lock.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(false);

            _notAvialable.gameObject.SetActive(true);
            
        }
        
        else 
        {
            _lock.gameObject.SetActive(true);
            _buyButton.gameObject.SetActive(true);

            _notAvialable.gameObject.SetActive(false);
        }
    }
}
