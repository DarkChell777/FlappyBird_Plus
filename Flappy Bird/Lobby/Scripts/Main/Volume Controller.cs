using System;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSourse;
    [SerializeField] private AudioSource _musicSourse;
    [SerializeField] private AudioClip _buttonClip;

    private const string soundString = "SoundValue";
    private const string musicString = "MusicValue";
    private float _soundValue;
    private float _musicValue;

    public float Sound => _soundValue;
    public float Music => _musicValue;

    private void Awake()
    {
        LoadValuesFromConfing();
    }

    public void SetSoundValue(float value)
    {
        _soundSourse.volume = value;
        _soundValue = value;
    }

    public void SetMusicValue(float value)
    {
        _musicSourse.volume = value;
        _musicValue = value;
    }

    public void SetSound(AudioClip clip)
    {
        _soundSourse.clip = clip;
    }

    public void PlaySound()
    {
        _soundSourse.Play();
    }

    public void ResetSound()
    {
        _soundSourse.clip = _buttonClip;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(soundString, _soundValue);
        PlayerPrefs.SetFloat(musicString, _musicValue);
        PlayerPrefs.Save();
    }

    public void Mute()
    {
        _soundSourse.mute = true;
        _musicSourse.mute = true;
    }

    private void LoadValuesFromConfing()
    {
        float soundValue = PlayerPrefs.GetFloat(soundString, 1.0f);
        float musicValue = PlayerPrefs.GetFloat(musicString, 1.0f);

        _soundSourse.volume = soundValue;
        _soundValue = soundValue;

        _musicSourse.volume = musicValue;
        _musicValue = musicValue;
    }
}
