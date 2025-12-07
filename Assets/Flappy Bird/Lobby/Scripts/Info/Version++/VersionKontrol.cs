using System.Collections;
using UnityEngine;

public class VersionKontrol : MonoBehaviour
{
    [SerializeField] private DoingVersionActions _actions;
    [SerializeField] private VersionBinarySaver _saver;
    
    private void Awake()
    {
        bool isUnlock = _saver.LoadData();

        Debug.Log("Unlock: " + isUnlock);

        if (isUnlock) _actions.UnlockVersion();
    }
}
