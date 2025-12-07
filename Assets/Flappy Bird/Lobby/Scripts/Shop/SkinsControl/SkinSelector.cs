using UnityEngine;
using UnityEngine.UI;

public abstract class SkinSelector : MonoBehaviour
{
    [SerializeField] protected Button _selectButton;

    protected abstract void OnEnable();
    protected abstract void OnDisable();
    public abstract void SetData(int skin);
    public abstract void SelectingSkin();
}
