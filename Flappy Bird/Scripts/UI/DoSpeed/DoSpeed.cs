using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InviseButton))]
[RequireComponent(typeof(CheckBalanceForSpeed))]
public class DoSpeed : MonoBehaviour
{
    [SerializeField] private SpeedChanging _speedChanger;
    [SerializeField] private InviseButton _buttonInviser;
    [SerializeField] private Game _game;
    [SerializeField] private CheckBalanceForSpeed _checker;
    [SerializeField] private Button _button;
    [SerializeField] private float _targetSpeed = 90f;

    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (_checker.CheckBalance())
        {
            _buttonInviser.HideButton();
            _game.Restart();
            _speedChanger.SetSpeed(_targetSpeed);
        }
    }
}
