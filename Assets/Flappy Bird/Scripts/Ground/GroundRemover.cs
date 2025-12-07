using UnityEngine;

public class GroundRemover : MonoBehaviour
{
    [SerializeField] private GroundObjectPool _groundPool;
    
    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IsGround ground))
        {
            _groundPool.PutObject(ground);
            //other.enabled = false;
        }
    }
}
