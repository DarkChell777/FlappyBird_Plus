using System.Collections;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private GroundObjectPool _pool;
    [SerializeField] private GameObject _groundOrig;
    [SerializeField] private GroundCollisionEnd _handler;

    private void OnEnable()
    {
        _handler.OnEndCollisionEnter += GenerateGroundContinuation;
    }

    private void OnDisable()
    {
        _handler.OnEndCollisionEnter -= GenerateGroundContinuation;
    }

    private void GenerateGroundContinuation(Vector3 groundPosition)
    {
        Vector3 newPosition = groundPosition + new Vector3(GetComponent<Ground>().GetWidth(), 0f, 0f);

        _pool.GetObject(newPosition);
    }
}
