using UnityEngine;
using UnityEngine.UI;

public class SoundSliderChanger : MonoBehaviour
{
    [SerializeField] private AudioManager _volumeController;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.value = _volumeController.Sound;
    }

    public void OnScliderChangeValue()
    {
        _volumeController.SetSound(_slider.value);
    }
}
