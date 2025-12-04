using System;
using UnityEngine;

public class CollisionEndHandler : MonoBehaviour
{
    public bool IsTriggered{get; private set;} = false;
    public event Action<Vector3> OnEndCollisionEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ISecondBirdCollider bird) && !IsTriggered)
        {
            IsTriggered = true;
            OnEndCollisionEnter?.Invoke(transform.position);
        }
    }
}
