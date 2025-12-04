using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PasswordGenerate))]
public class InputControl : MonoBehaviour
{
    [SerializeField] private DoingVersionActions _actions;
    [SerializeField] private PasswordGenerate _passwordGenerate;
    [SerializeField] private VersionKontrol _control;
    [SerializeField] private TextMeshProUGUI _input;
    [SerializeField] private Button _enterButton;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _wrongClip;
    [SerializeField] private AnimationClip _rightClip;
    [SerializeField] private Button[] _buttons;


    private string _inputText = "";
    private string _startdartText;

    private void Awake()
    {
        _enterButton.onClick.AddListener(OnEnter);
        _deleteButton.onClick.AddListener(OnDelete);

        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i; 
            _buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }

        _startdartText = _input.text;
    }

    public void OnButtonClick(int index)
    {
        if (_inputText.Length < 10)
        {
            _inputText += index.ToString();

            UpdateInputDisplay();
        }
    }

    public void Reset()
    {
        _inputText = "";
        _input.text = _startdartText;
    }

    public void OnEnter()
    {
        if (_inputText == null) return;

        StartCoroutine(Waiter());
        
        ActionType passwordResult = _passwordGenerate.OnCheckPassword(_inputText);

        if (passwordResult == ActionType.UnlockVersion) 
        {
            PasswordRight();

            _actions.UnlockVersion();
        }

        else if (passwordResult == ActionType.ResetProgress) 
        {
            PasswordRight();

            _actions.ResetProgress();
        }

        else if (passwordResult == ActionType.GiveMoney) 
        {
            PasswordRight();

            _actions.GivingMoney();
        }

        else if (passwordResult == ActionType.Give20Money) 
        {
            PasswordRight();

            _actions.Giving20Money();
        }

        else if (passwordResult == ActionType.UnlockGift) 
        {
            PasswordRight();

            _actions.UnlockGift();
        }

        else PasswordWrong();
    }

    public void OnDelete()
    {
        _inputText = _inputText.Substring(0, _inputText.Length - 1);
        UpdateInputDisplay();
    }

    private void UpdateInputDisplay()
    {
        _input.text = new string('*', _inputText.Length);
    }

    private void Clear()
    {
        _inputText = "";

        UpdateInputDisplay();
    }

    private void PasswordRight()
    {
        _animator.Play(_rightClip.name);
    }

    private void PasswordWrong()
    {
        _animator.Play(_wrongClip.name);
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1.2f);

        Clear();

        gameObject.SetActive(false);
    }
}
