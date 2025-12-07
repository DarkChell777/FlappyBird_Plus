using UnityEngine;

public abstract class SkinButtonControl : MonoBehaviour
{
    [SerializeField] protected enum ButtonType { Left, Right }
    [SerializeField] protected ButtonType _buttonType;
    [SerializeField] protected AnimationClip _leftAnimation; 
    [SerializeField] protected AnimationClip _rightAnimation; 

    [SerializeField] protected Animator _animator; 

    public abstract void OnClicked();
}
