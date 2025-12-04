using UnityEngine;

public class CheckBalanceForSpeed : MonoBehaviour
{
    [SerializeField] private DataSaver _saver;
    [SerializeField, Range(0, 10)] private int _price = 2;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _clip;

    public bool CheckBalance()
    {
        int nowBalance = _saver.Balance;

        if (nowBalance >= _price) 
        {
            _saver.SetBalance(nowBalance - _price);
            return true;
        }
        else 
        {
            _animator.Play(_clip.name);
            return false;
        }
    }
}
