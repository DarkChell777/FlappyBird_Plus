using System.Collections;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private CoinsObjectPool _pool;
    [SerializeField] private CoinsDifficult _coinsDifficult;
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private Game _game;

    private Difficults _difficult => _coinsDifficult.Difficult;


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
        StartCoroutine(GenerateCoins());
    }

    private void StopGenerate()
    {
        StopAllCoroutines();
    }

    private float DelayCalculate()
    {
        float delay = Random.Range(_difficult.minDelayForCoin, _difficult.maxDelayForCoin);

        return delay;
    }


    private IEnumerator GenerateCoins()
    {
        while (enabled)
        {
            Spawn();

            yield return new WaitForSeconds(DelayCalculate());
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_difficult.upperBoundForCoin, _difficult.maxDelayForCoin);
        Vector3 _spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var coin = _pool.GetObject(_spawnPosition);
    }
}
