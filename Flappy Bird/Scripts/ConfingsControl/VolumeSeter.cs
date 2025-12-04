using UnityEngine;

public class VolumeSeter : MonoBehaviour
{
    [SerializeField] private AudioManager _manager;

    public void SetVolume(float music, float sound)
    {
        _manager.SetVolums(music, sound);
    }
}
