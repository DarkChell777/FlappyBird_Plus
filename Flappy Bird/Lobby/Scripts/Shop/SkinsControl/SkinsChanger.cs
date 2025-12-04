using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinsChanger : MonoBehaviour
{
    [SerializeField] protected Image _skin;
    [SerializeField] protected TextMeshProUGUI _infoText;

    protected virtual void OnEnable() {}
    protected virtual void OnDisable() {}

    public virtual void ChangeSkin(int index) {}
}
