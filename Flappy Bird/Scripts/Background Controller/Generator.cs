using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundOrig;
    [SerializeField] private CollisionEndHandler _handler;
    [SerializeField] private Transform _container;

    private void OnEnable()
    {
        _handler.OnEndCollisionEnter += GenerateBackgroundContinuation;
    }

    private void OnDisable()
    {
        _handler.OnEndCollisionEnter -= GenerateBackgroundContinuation;
    }

    private void GenerateBackgroundContinuation(Vector3 backgroundPosition)
    {
        GameObject newBackground = Instantiate(_backgroundOrig, _container);

        Vector3 newPosition = backgroundPosition + new Vector3(GetComponent<Background>().GetWidth(), 0f, 0f);

        newBackground.transform.position = newPosition;
    }

}
