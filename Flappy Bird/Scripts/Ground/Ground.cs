using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private GroundObjectPool _groundPool;
    [SerializeField] private Game _gameMessages;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _sizer;

    private void OnEnable()
    {
        _gameMessages.GameRestart += Reset;
    }

    private void OnDisable()
    {
        _gameMessages.GameRestart -= Reset;
    }

    public float GetWidth()
    {
        return _sizer.GetComponent<BoxCollider2D>().bounds.size.x;
    }

    private void Reset()
    {        
        foreach (Transform child in _container)
        {
            bool hasComponent = child.TryGetComponent(out IsGround ground);
            
            if (hasComponent)
            {
                _groundPool.PutObject(ground);
            }
        }
        _groundPool.GetObject(_startPosition.position);
    }
}
