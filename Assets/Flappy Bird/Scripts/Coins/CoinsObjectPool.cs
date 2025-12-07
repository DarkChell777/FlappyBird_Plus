using System.Collections.Generic;
using UnityEngine;

public class CoinsObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private ICoin _prefab;

    private Queue<ICoin> _pool;

    public IEnumerable<ICoin> PooledObjects => _pool;
    public ICoin Prefab => _prefab;

    private void Awake()
    {
        _pool = new Queue<ICoin>();
    }

    public ICoin GetObject(Vector3 spawnPosition)
    {
        ICoin coin;

        if (_pool.Count == 0)
        {
            coin = Instantiate(_prefab);
            coin.transform.parent = _container;
        } else {
            coin = _pool.Dequeue();
        }
    
        coin.transform.position = spawnPosition;
        coin.gameObject.SetActive(true); 

        return coin;
    }

    public void PutObject(ICoin coin)
    {
        coin.gameObject.SetActive(false);
        _pool.Enqueue(coin);
    }

    public void ReturnAllObjectsToPool()
    {
    foreach (Transform child in _container)
    {
        if (child.TryGetComponent(out ICoin coin)) 
        {
            PutObject(coin); 
        }
    }
}
    public void Reset()
    {
        _pool.Clear();
    }

}
