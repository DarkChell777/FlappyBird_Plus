using UnityEngine;

public class PlayerPriceViewer : SkinPriceViewer
{
    [SerializeField] private PlayerSkinManager _manager;
    
    private PlayerSkin[] _skins => _manager.PlayerSkins.Characters;

    protected override void OnEnable() {_manager.SkinChanging += UpdatePrice;}

    protected override void OnDisable() {_manager.SkinChanging -= UpdatePrice;}
    

    public override void UpdatePrice(int index)
    {
        _price.text = _skins[index].price.ToString();
    }
    
}
