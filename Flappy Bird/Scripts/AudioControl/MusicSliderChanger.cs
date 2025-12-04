using UnityEngine;
using UnityEngine.UI;

public class MusicSliderChanger : MonoBehaviour
{
    [SerializeField] private AudioManager _volumeController;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.value = _volumeController.Music;
    }

    public void OnScliderChangeValue()
    {
        _volumeController.SetMusic(_slider.value);
    }
}
