using UnityEngine;

public class BackgroundPriceViewer : SkinPriceViewer
{
    [SerializeField] private BackgroundSkinManager _manager;

    private BackgroundSkin[] _skins => _manager.BackgroundSkins.Backgrounds;
    
    protected override void OnEnable() {_manager.SkinChanging += UpdatePrice;}

    protected override void OnDisable() {_manager.SkinChanging -= UpdatePrice;}
    

    public override void UpdatePrice(int index)
    {
        _price.text = _skins[index].price.ToString();  
    }
    
}
