using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Video_Start : MonoBehaviour
{
    [SerializeField] private VolumeController _volumeController;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private float _secondsForSkip;

    public void StartVideo()
    {
        _videoPlayer.gameObject.SetActive(true);
        _videoPlayer.Play();
        StartCoroutine(SkipVideoCoroutine());
        _volumeController.Mute();
    }

    private IEnumerator SkipVideoCoroutine()
    {
        float _outTime = _secondsForSkip;

        while (_outTime > 0)
        {
            _outTime -= Time.deltaTime;
            yield return null; 
        }

        _videoPlayer.skipOnDrop = true;
    }
}
