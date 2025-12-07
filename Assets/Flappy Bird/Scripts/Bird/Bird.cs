using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private BirdCollisionHandler _handler;

    public event Action GameOver;

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _birdMover.Reset();
    }
}

