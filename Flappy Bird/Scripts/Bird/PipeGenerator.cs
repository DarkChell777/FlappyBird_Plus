using System.Collections;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float[] _lowerBound = new float[2];
    [SerializeField] private float[] _upperBound = new float[2];
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private Game _game;

    private int _currentDifficult => _pool.currentDifficult;

    private void OnEnable()
    {
        _birdMover.BirdStarted += StartGenerate;
        _game.GameRestart += StopGenerate;
    }

    private void OnDisable()
    {
        _birdMover.BirdStarted -= StartGenerate;
        _game.GameRestart -= StopGenerate;
    }

    private void StartGenerate()
    {
        Debug.Log("start");
        StartCoroutine(GeneratePipes());
    }

    private void StopGenerate()
    {
        Debug.Log("stop");
        StopAllCoroutines();
    }


    private IEnumerator GeneratePipes()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound[_currentDifficult], _lowerBound[_currentDifficult]);
        Vector3 _spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        _pool.GetObject(_spawnPosition);
    }

    public void SetDelay(float delay)
    {
        _delay = delay;
    }
}
