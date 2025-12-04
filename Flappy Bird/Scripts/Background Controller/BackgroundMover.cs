using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Game _game;
    //[SerializeField] private Transform _ground;
    [SerializeField] private float _delaySpeed;

    public float DelaySpeed => _delaySpeed;

    private float _xOffset;

    private void OnEnable()
    {
        _game.GameRestart += Reset;
    }

    private void OnDisable()
    {
        _game.GameRestart -= Reset;
    }

    private void Update()
    {
        var newPosition = _bird.transform.position.x;
        newPosition = _bird.transform.position.x - _xOffset;
        _xOffset += _delaySpeed * Time.deltaTime;
        transform.position = new Vector3(newPosition, transform.position.y, 0);

        /*
        var groundPosition = _ground.transform.position;
        groundPosition.x = _bird.transform.position.x;
        _ground.transform.position = groundPosition;
        */
    }

    public void Reset()
    {
        _xOffset = 0f;
    }
}
