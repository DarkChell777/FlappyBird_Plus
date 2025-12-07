using UnityEngine;
using UnityEngine.UI;

public class SoundChangerValue : MonoBehaviour
{
    [SerializeField] private VolumeController _volumeController;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _volumeController.Sound;
    }

    public void OnScliderChangeValue()
    {
        _volumeController.SetSoundValue(_slider.value);
    }
}
