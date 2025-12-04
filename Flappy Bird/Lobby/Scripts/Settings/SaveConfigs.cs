using UnityEngine;

public class SaveConfigs : MonoBehaviour
{
    [SerializeField] private VolumeController _volumeController;

    public void OnExit()
    {
        _volumeController.Save();
    }
}