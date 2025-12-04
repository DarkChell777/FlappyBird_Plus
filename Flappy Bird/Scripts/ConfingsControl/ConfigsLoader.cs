using System;
using UnityEngine;

[RequireComponent(typeof(GameModeSeter))]
[RequireComponent(typeof(DifficultSeter))]
[RequireComponent(typeof(VolumeSeter))]
[RequireComponent(typeof(SkinSeter))]
[RequireComponent(typeof(BackgroundSeter))]
public class ConfigsLoader : MonoBehaviour
{
    private const string currentMode = "CurrentMode";
    private const string currentDifficult = "CurrentDifficult";
    private const string musicValue = "MusicValue";
    private const string soundValue = "SoundValue";
    private const string currentPlayerSkin = "PlayerCurrentSkin";
    private const string currentBackgroundSkin = "BackgroundCurrentSkin";

    private int _mode;
    private int _difficulty;
    private float _musicValue;
    private float _soundValue;
    private int _playerSkin;
    private int _backgroundSkin;

    private void Start()
    {
        _mode = PlayerPrefs.GetInt(currentMode, 0);
        _difficulty = PlayerPrefs.GetInt(currentDifficult, 2);
        _musicValue = PlayerPrefs.GetFloat(musicValue, 1);
        _soundValue = PlayerPrefs.GetFloat(soundValue, 1);
        _playerSkin = PlayerPrefs.GetInt(currentPlayerSkin, 0);
        _backgroundSkin = PlayerPrefs.GetInt(currentBackgroundSkin, 0);

        GetComponent<GameModeSeter>().SetGameMode(_mode);
        GetComponent<DifficultSeter>().SetDifficult(_difficulty);
        GetComponent<VolumeSeter>().SetVolume(_musicValue, _soundValue);
        GetComponent<SkinSeter>().SetSkin(_playerSkin);
        GetComponent<BackgroundSeter>().SetSkin(_backgroundSkin);
    }


}
