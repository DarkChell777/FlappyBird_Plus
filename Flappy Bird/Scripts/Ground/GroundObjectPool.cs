using System.Collections.Generic;
using UnityEngine;

public class GroundObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private IsGround _prefab;

    private Queue<IsGround> _pool;

    public IEnumerable<IsGround> PooledObjects => _pool;
    public IsGround Prefab => _prefab;

    private void Awake()
    {
        _pool = new Queue<IsGround>();
    }

    public IsGround GetObject(Vector3 spawnPosition)
    {
        IsGround coin;

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

    public void PutObject(IsGround ground)
    {
        ground.gameObject.SetActive(false);
        _pool.Enqueue(ground);
    }

    public void ReturnAllObjectsToPool()
    {
    foreach (Transform child in _container)
    {
        if (child.TryGetComponent(out IsGround ground)) 
        {
            PutObject(ground); 
        }
    }
}
    public void Reset()
    {
        _pool.Clear();
    }

}
