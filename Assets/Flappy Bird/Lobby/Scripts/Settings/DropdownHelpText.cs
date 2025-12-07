using TMPro;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(DifficultControl))]
public class DropdownHelpText : MonoBehaviour, IBackgroundHelpTexts
{
    [SerializeField] private TextMeshProUGUI _helpText;
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private DifficultControl _difficultControl;

    private Dictionary<string, string> _helpTextsList;

    void Start()
    {
        _helpTextsList = new Dictionary<string, string>
        {
            { _dropdown.options[0].text, IBackgroundHelpTexts.PrizrakDifficultText},
            { _dropdown.options[1].text, IBackgroundHelpTexts.EasyDifficultText},
            { _dropdown.options[2].text, IBackgroundHelpTexts.NormalDifficultText},
            { _dropdown.options[3].text, IBackgroundHelpTexts.HardDifficultText}
        };

        _dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    public void OnDropdownChanged(int index)
    {
        string selectedKey = _dropdown.options[index].text;
        
        if (_helpTextsList.ContainsKey(selectedKey))
        {
            _helpText.text = _helpTextsList[selectedKey];
            _difficultControl.ChangingDifficult(index);
        }
    }

    public void SetValue(int index)
    {
        _dropdown.value = index;
    }
}
