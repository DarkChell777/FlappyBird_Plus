using UnityEngine;

public class CoinsRemover : MonoBehaviour
{
    [SerializeField] private CoinsObjectPool _pool;
    
    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool hasComponent = other.TryGetComponent<ICoin>(out ICoin coin);

        if (!hasComponent) return;
        
        _pool.PutObject(coin);
        
    }
}
