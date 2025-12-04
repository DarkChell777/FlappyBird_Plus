using System;
using UnityEngine;

[RequireComponent(typeof(BackgroundSkinChanger))]
[RequireComponent(typeof(BackgroundSkinChecker))]
[RequireComponent(typeof(BackgroundSkinSelect))]
[RequireComponent(typeof(BackgroundBuyerControl))]
[RequireComponent(typeof(BackgroundPriceViewer))]
public class BackgroundSkinManager : SkinManager
{
    [SerializeField] private BackgroundSkinChanger _changer;
    [SerializeField] private BackgroundSkins _skins;

    private int _currentSkinIndex;
    private int _selectedSkin;
    public new int SkinIndex => _currentSkinIndex;
    public event Action<int> SkinChanging;
    public BackgroundSkins BackgroundSkins => _skins;

    private const string currentSkin = "BackgroundCurrentSkin";


    private void Start()
    {
        LoadData();
    }

    public override void GoToLeft()
    {
        _currentSkinIndex--;

        if (_currentSkinIndex < 0)
        {
            _currentSkinIndex = _skins.Backgrounds.Length - 1;
        }

        UpdateSkin();
    }

    public override void GoToRight()
    {
        _currentSkinIndex++;

        if (_currentSkinIndex >= _skins.Backgrounds.Length) _currentSkinIndex = 0;

        UpdateSkin();
    }

    public override void UpdateSkin()
    {     
        SkinChanging?.Invoke(_currentSkinIndex);
    }

    public override void SetSkin(int index)
    {
        _currentSkinIndex = index;
        UpdateSkin();
    }

    public override bool IsUnlock(int index)
    {
        return _controller.IsBSkinUnlocked(_skins.Backgrounds[index].skin);
    }

    public override bool IsSelectedSkin(int index)
    {
        if (_selectedSkin == index) return true;

        return false;
    }

    public override void SaveData()
    {
        _selectedSkin = _currentSkinIndex;
        PlayerPrefs.SetInt(currentSkin, _currentSkinIndex);
        PlayerPrefs.Save();
    }

    public override void LoadData()
    {
        int newIndex = PlayerPrefs.GetInt(currentSkin, 0);
        _currentSkinIndex = newIndex;
        _selectedSkin = newIndex;
        UpdateSkin();
    }
}