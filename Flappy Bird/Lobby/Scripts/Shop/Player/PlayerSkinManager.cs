using System;
using UnityEngine;

[RequireComponent(typeof(PlayerSkinChanger))]
[RequireComponent(typeof(CharacktersChanger))]
[RequireComponent(typeof(PlayerSkinChecker))]
[RequireComponent(typeof(PlayerSkinSelect))]
[RequireComponent(typeof(PlayerBuyerControl))]
[RequireComponent(typeof(PlayerPriceViewer))]
public class PlayerSkinManager : SkinManager
{
    [SerializeField] private PlayerSkinChanger _changer;
    [SerializeField] private PlayerSkins _skins;

    private int _currentSkinIndex;
    private int _selectedSkin;
    public new int SkinIndex => _currentSkinIndex;
    public event Action<int> SkinChanging;
    public PlayerSkins PlayerSkins => _skins;

    private const string currentSkin = "PlayerCurrentSkin";


    private void Start()
    {
        LoadData();
    }

    public override void GoToLeft()
    {
        _currentSkinIndex--;

        if (_currentSkinIndex < 0)
        {
            _currentSkinIndex = _skins.Characters.Length - 1;
        }

        UpdateSkin();
    }

    public override void GoToRight()
    {
        _currentSkinIndex++;

        if (_currentSkinIndex >= _skins.Characters.Length) _currentSkinIndex = 0;

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
        bool isUnlok = _controller.IsPSkinUnlocked(_skins.Characters[index].skin);
        return isUnlok;
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


