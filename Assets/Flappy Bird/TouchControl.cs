using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private bool _buttonMode = true;

    public event Action OnInputClicked;

    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void Start()
    {
        _inputSystem.Player.Click.started += ctx => StartTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {

        if (!_buttonMode) OnInputClicked?.Invoke();
        
    }

    public void ButtonClicked()
    {
        if (_buttonMode)
        {
            OnInputClicked?.Invoke();
        }
    }
}
