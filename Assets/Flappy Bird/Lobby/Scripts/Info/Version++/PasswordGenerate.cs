using UnityEngine;

public class PasswordGenerate : MonoBehaviour
{
    [SerializeField] private PasswordHandler[] _passwords;

    [System.Serializable]
    private class PasswordHandler
    {
        public string password;
        public ActionType actionType;
    }

    public ActionType OnCheckPassword(string password)
    {
        foreach (var action in _passwords)
        {
            if (action.password == password)
            {
                return action.actionType;
            }
        }

        return ActionType.None;
    }
}

public enum ActionType
{
    None,
    GiveMoney,
    UnlockVersion,
    ResetProgress,
    Give20Money,
    UnlockGift
}
