using UnityEngine;

public class GiftButton : MonoBehaviour
{
    [SerializeField] private GiftManager _giftManager;
  
    public void OnClick()
    {
        _giftManager.TryOpenGift();
    }
}
