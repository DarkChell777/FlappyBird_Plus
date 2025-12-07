using TMPro;
using UnityEngine;

public class SkinPriceViewer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _price;

    protected virtual void OnEnable() {}
    protected virtual void OnDisable() {}

    public virtual void UpdatePrice(int index) {}


}
