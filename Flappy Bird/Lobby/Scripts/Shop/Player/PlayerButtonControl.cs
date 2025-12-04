using UnityEngine;

public class PlayerButtonControl : SkinButtonControl
{
    [SerializeField] private PlayerSkinManager _manager;

    public override void OnClicked() 
    {
        if (_buttonType == ButtonType.Left)
        {
            _animator.Play(_leftAnimation.name); 
            _manager.GoToLeft();
        }
        else if (_buttonType == ButtonType.Right) 
        {
            _animator.Play(_rightAnimation.name); 
            _manager.GoToRight();
        }
    }
}
