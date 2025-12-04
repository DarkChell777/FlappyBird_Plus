using UnityEngine;

public class PlayerSkinChanger : SkinsChanger
{
    [SerializeField] private PlayerSkinManager _manager;
    [SerializeField] private PlayerSkins _skins;
    
    protected override void OnEnable() {_manager.SkinChanging += ChangeSkin;}

    protected override void OnDisable() {_manager.SkinChanging -= ChangeSkin;}

    public override void ChangeSkin(int index)
    {
        _skin.sprite = _skins.Characters[index].sprite;

        _infoText.text = _skins.Characters[index].About;
    }
    
}


