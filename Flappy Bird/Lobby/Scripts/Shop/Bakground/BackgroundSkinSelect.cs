using UnityEngine;

public class BackgroundSkinSelect : SkinSelector 
{
    [SerializeField] private BackgroundSkinManager _manager;
    [SerializeField] private BackgroundSkinChanger _changer;

    private int _currentSkinIndex;

    private void Awake()
    {
        _selectButton.onClick.AddListener(SelectingSkin);
    }

    protected override void OnEnable() {_manager.SkinChanging += SetData;}

    protected override void OnDisable() {_manager.SkinChanging -= SetData;}

    public override void SetData(int index)
    {
        _currentSkinIndex = index;
    }

    public override void SelectingSkin()
    {
        _manager.SetSkin(_currentSkinIndex);
        _manager.SaveData();
        _manager.UpdateSkin();
    }
}