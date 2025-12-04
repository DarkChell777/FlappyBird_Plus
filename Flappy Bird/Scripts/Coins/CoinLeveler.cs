using UnityEngine;

public class CoinLeveler : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void AlginCoin(IInteractable interactable)
    {
        Vector2 direction = (transform.position - interactable.transform.position).normalized;

        transform.position += (Vector3)direction * _speed * Time.deltaTime;
    }
}
