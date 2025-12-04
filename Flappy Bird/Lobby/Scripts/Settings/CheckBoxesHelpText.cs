using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(ModeControl))]
public class CheckBoxesHelpText : MonoBehaviour, IBackgroundHelpTexts
{
    [SerializeField] private ModeControl _modeControl;
    [SerializeField] private TextMeshProUGUI _helpText;
    [SerializeField] private Toggle[] _toggles;

    private Dictionary<string, string> _helpTextsList;
    private string[] _developmentModes;

    private void Start()
    {
        _developmentModes = new string[] 
        {
            _toggles[2].name, 
            _toggles[3].name, 
            _toggles[4].name, 
            _toggles[5].name
        };

        _helpTextsList = new Dictionary<string, string>
        {
            { _toggles[0].name, IBackgroundHelpTexts.KlassikText},
            { _toggles[1].name, IBackgroundHelpTexts.DefaultText},
            { _toggles[2].name, IBackgroundHelpTexts.ThisModeInDevelopmentText},
            { _toggles[3].name, IBackgroundHelpTexts.ThisModeInDevelopmentText},
            { _toggles[4].name, IBackgroundHelpTexts.ThisModeInDevelopmentText},
            { _toggles[5].name, IBackgroundHelpTexts.ThisModeInDevelopmentText},
        };

        foreach (var toggle in _toggles)
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
        }
    }

    public void OnToggleChanged(bool isOn)
    {
        for (int i = 0; i < _toggles.Length; i++)
        {
            string text = _helpTextsList[_toggles[i].name];
            if (_toggles[i].isOn && _helpTextsList.ContainsKey(_toggles[i].name))
            {
                _helpText.text = text;

                _modeControl.ChangingMode(i);

                if (_developmentModes.Any(mode => mode == _toggles[i].name)) _modeControl.OffButton();
            
                else _modeControl.OnButton();

                break;
            }
        }
    }

    public void ResetText()
    {
        _helpText.text = "";
    }

    public void SetToggle(int index)
    {
        _toggles[index].isOn = true;
    }
}
