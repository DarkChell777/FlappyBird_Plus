using UnityEngine;

public class PipeRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private int currentDifficult => _pool.currentDifficult;

    
    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool hasComponent = other.TryGetComponent<Pipe>(out Pipe pipe);

        if (!hasComponent) return;

        if (other.name == _pool.prefabs[currentDifficult].name + "(Clone)") _pool.PutObject(pipe);

        else Destroy(other.gameObject);
    }
}
