using UnityEngine;
using UnityEngine.UI;

public class ModeControl : MonoBehaviour 
{
    [SerializeField] private CheckBoxesHelpText _helpTextControl;
    [SerializeField] private Button _exitButton;

    private const string currentMode = "CurrentMode";
    private int _currentCheckBoxIndex;

    private void Start()
    {
        Load();
    }

    public void OffButton()
    {
        _exitButton.interactable = false;
    }

    public void OnButton() 
    {
        _exitButton.interactable = true;
    }
    

    public void ChangingMode(int index)
    {
        _currentCheckBoxIndex = index;
    }

    public void OnExit()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(currentMode, _currentCheckBoxIndex);
    }

    private void Load()
    {
        int loadIndex = PlayerPrefs.GetInt(currentMode, 2);
        _currentCheckBoxIndex = loadIndex;
        _helpTextControl.SetToggle(_currentCheckBoxIndex);
    }
}