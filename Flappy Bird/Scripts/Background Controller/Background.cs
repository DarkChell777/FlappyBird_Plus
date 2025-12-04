using UnityEngine;


public class Background : MonoBehaviour
{
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
        if (GetComponent<CollisionEndHandler>().IsTriggered) return;
        
        foreach (Transform child in _container)
        {
            bool hasComponent = child.TryGetComponent(out IsBackground background);
            if (hasComponent && !child.GetComponent<CollisionEndHandler>().IsTriggered) 
            {
                child.transform.position = _startPosition.position;
            } 
            else if (hasComponent)
            {
                Destroy(child.gameObject);
            }
            
        }
    }
}
