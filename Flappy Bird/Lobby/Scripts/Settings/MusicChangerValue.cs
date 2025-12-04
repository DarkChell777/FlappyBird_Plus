using UnityEngine;
using UnityEngine.UI;

public class MusicChangerValue : MonoBehaviour
{
    [SerializeField] private VolumeController _volumeController;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _volumeController.Music;
    }

    public void OnScliderChangeValue()
    {
        _volumeController.SetMusicValue(_slider.value);
    }
}