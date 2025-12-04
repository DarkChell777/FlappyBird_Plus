using UnityEngine;
using UnityEngine.UI;

public class DifficultControl : MonoBehaviour 
{
    [SerializeField] private DropdownHelpText _helpTextControl;
    [SerializeField] private Button _exitButton;

    private const string currentDifficult = "CurrentDifficult";
    private int _currentDifficultIndex;

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
    

    public void ChangingDifficult(int index)
    {
        _currentDifficultIndex = index;

        if (index == 0) _exitButton.interactable = false;

        else _exitButton.interactable = true;
        
    }

    public void OnExit()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(currentDifficult, _currentDifficultIndex);
    }

    private void Load()
    {
        int loadIndex = PlayerPrefs.GetInt(currentDifficult, 2);
        _currentDifficultIndex = loadIndex;
        _helpTextControl.SetValue(_currentDifficultIndex);
    }
}