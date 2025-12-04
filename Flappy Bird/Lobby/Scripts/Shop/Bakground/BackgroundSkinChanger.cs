using UnityEngine;

public class BackgroundSkinChanger : SkinsChanger
{
    [SerializeField] private BackgroundSkinManager _manager;
    [SerializeField] private BackgroundSkins _skins;

    
    protected override void OnEnable() {_manager.SkinChanging += ChangeSkin;}

    protected override void OnDisable() {_manager.SkinChanging -= ChangeSkin;}

    public override void ChangeSkin(int index)
    {
        _skin.sprite = _skins.Backgrounds[index].shopSprite;

        _infoText.text = _skins.Backgrounds[index].About;
    }
    
}


