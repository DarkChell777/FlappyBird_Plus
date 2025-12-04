using UnityEngine;

public class GroundCollisionEnd : MonoBehaviour
{
    public event System.Action<Vector3> OnEndCollisionEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ISecondBirdCollider bird))
        {
            OnEndCollisionEnter?.Invoke(transform.position);
        }
    }
}
