using UnityEngine;

public class Remover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IsBackground background))
        {
            Destroy(other.gameObject);
            other.enabled = false;
        }
    }
}
