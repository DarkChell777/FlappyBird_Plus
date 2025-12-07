using UnityEngine;

public class BackgroundSkinChecker : SkinsChecker
{
    [SerializeField] private BackgroundSkinManager _manager;
    [SerializeField] private BackgroundSkinChanger _changer;
    [SerializeField] private BackgroundSkins _skins;

    private BackgroundSkin _skin;

    protected override void OnEnable() {_manager.SkinChanging += CheckSkin;}

    protected override void OnDisable() {_manager.SkinChanging -= CheckSkin;}

    public override void CheckSkin(int index)
    {
        _skin = _skins.Backgrounds[index];

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
