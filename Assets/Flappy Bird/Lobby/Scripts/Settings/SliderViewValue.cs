using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderViewValue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        OnScliderChangeValue();
    }

    public void OnScliderChangeValue()
    {
        _text.text = (_slider.value * 100).ToString("F0");
    }
}
