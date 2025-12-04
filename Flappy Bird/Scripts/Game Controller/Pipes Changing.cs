using UnityEngine;

public class PipesChanging : MonoBehaviour
{
    [SerializeField] private ObjectPool _poolHandler;
    [SerializeField] private PipeGenerator _generator;
    [SerializeField] private GameDifficult _gameDifficult;

    private void OnEnable()
    {
        _gameDifficult.DifficultChanged += SetDifficult;
    }

    private void OnDisable()
    {
        _gameDifficult.DifficultChanged -= SetDifficult;
    }

    private void SetDifficult(Difficults difficult)
    {
        if (difficult.type == DifficultsType.Normal)
        {
            ChangeCurrentColumnsForNormal(difficult.pointsPipesDelayInSecond);
        }

        if (difficult.type == DifficultsType.Hard)
        {
            ChangeCurrentColumnsForHard(difficult.pointsPipesDelayInSecond);
        }
    }

    private void ChangeCurrentColumnsForNormal(float generateDelay)
    {
        _poolHandler.ChangePrefab(1);
        _generator.SetDelay(generateDelay);
    }

    private void ChangeCurrentColumnsForHard(float generateDelay)
    {
        _poolHandler.ChangePrefab(2);
        _generator.SetDelay(generateDelay);
    }
}
