using UnityEngine;

public class CoinsDifficult : MonoBehaviour 
{
    [SerializeField] private GameDifficult _gameDifficult;

    public DifficultsType DifficultType => _gameDifficult.CurrentDifficult;
    public Difficults Difficult => _gameDifficult.Difficult;
}