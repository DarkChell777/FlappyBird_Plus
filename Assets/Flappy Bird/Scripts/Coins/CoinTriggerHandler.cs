using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CoinTriggerHandler : MonoBehaviour
{
    public event Action<ISecondBirdCollider> CoinCollisioning;

    private CoinLeveler _leveler;

    private void Awake()
    {
        _leveler = GetComponent<CoinLeveler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ISecondBirdCollider>(out ISecondBirdCollider bird))
        {
            CoinCollisioning?.Invoke(bird);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            _leveler.AlginCoin(interactable);
        }
    }

    private void OnValidate()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }
}
