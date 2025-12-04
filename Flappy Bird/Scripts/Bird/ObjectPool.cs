using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Pipe[] _prefab;

    private Queue<Pipe> _pool;

    public IEnumerable<Pipe> PooledObjects => _pool;
    [NonSerialized] public int currentDifficult;
    public Pipe[] prefabs => _prefab;


    private void Awake()
    {
        _pool = new Queue<Pipe>();
    }

    public Pipe GetObject(Vector3 spawnPosition)
    {
        Pipe pipe;

        if (_pool.Count == 0)
        {
            pipe = Instantiate(_prefab[currentDifficult]);
            pipe.transform.parent = _container;
        } 
        else {
            pipe = _pool.Dequeue();
        }
    
        pipe.transform.position = spawnPosition;
        pipe.gameObject.SetActive(true); 

        return pipe;
    }

    public void PutObject(Pipe pipe)
    {

        pipe.gameObject.SetActive(false);
        _pool.Enqueue(pipe);
    }

    public void ReturnAllObjectsToPool()
    {
        foreach (Transform child in _container)
        {
            if (child.TryGetComponent(out Pipe pipe) && child.gameObject.activeInHierarchy) 
            {
                PutObject(pipe); 
            }
        }
}
    public void Reset()
    {
        _pool.Clear();
    }

    public void ChangePrefab(int number)
    {
        Reset();
        currentDifficult = number;
    }
}
