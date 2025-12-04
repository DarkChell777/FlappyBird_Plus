using UnityEngine;
using UnityEngine.UI;

public class SkinsChecker : MonoBehaviour
{
    [SerializeField] protected Image _lock;
    [SerializeField] protected Image _notAvialable;
    [SerializeField] protected Button _buyButton;
    [SerializeField] protected Button _selectButton;

    protected virtual void OnEnable() {}
    protected virtual void OnDisable() {}

    public virtual void CheckSkin(int index) {}
}
