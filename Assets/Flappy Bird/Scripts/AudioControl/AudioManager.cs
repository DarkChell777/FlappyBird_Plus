using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private BackgroundSkins _backgroundSkins;
    [SerializeField] private PlayerSkins _playerSkins;
    [SerializeField] private Bird _bird;
    [SerializeField] private Game _game;
    [SerializeField] private PauseGame _pause;
    [SerializeField] private ContinueGame _continue;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _sound;

    public float Sound {get; private set;}
    public float Music {get; private set;}

    private const string soundString = "SoundValue";
    private const string musicString = "MusicValue";

    private void OnEnable()
    {
        _pause.OnPauseGame += OnPause;
        _continue.OnContinueGame += OnContinue;
        _bird.GameOver += _music.Stop;
        _game.GameRestart += Reset;
    }

    private void OnDisable()
    {
        _pause.OnPauseGame -= OnPause;
        _continue.OnContinueGame -= OnContinue;
        _bird.GameOver -= _music.Stop;
        _game.GameRestart -= Reset;
    }

    public void SetVolums(float music, float sound)
    {
        _music.volume = music;
        Music = music;

        _sound.volume = sound;
        Sound = sound;
    }

    public void SetMusic(float music)
    {
        _music.volume = music;
        Music = music;
    }

    public void SetSound(float sound)
    {
        _music.volume = sound;
        Sound = sound;
    }

    public void SetMusic(int index)
    {
        _music.clip = _backgroundSkins.Backgrounds[index].ambiend;
        _music.Play();
    }

    public void SetSound(int index)
    {
        _sound.clip = _playerSkins.Characters[index].sound;
    }

    public void PlaySound()
    {
        _sound.Play();
    }

    private void OnPause()
    {
        _music.Pause();
        _sound.Pause();
    }

    private void OnContinue()
    {
        _music.Play();
        _sound.Play();
    }

    private void Reset()
    {
        _music.Stop();
        _music.Play();

        _sound.Stop();
    }

    public void SaveValues()
    {
        PlayerPrefs.SetFloat(soundString, Sound);
        PlayerPrefs.SetFloat(musicString, Music);
        PlayerPrefs.Save();
    }
}
