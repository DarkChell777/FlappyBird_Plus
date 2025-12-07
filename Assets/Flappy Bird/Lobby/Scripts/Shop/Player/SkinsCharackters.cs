using UnityEngine;

public class SkinsCharacters : MonoBehaviour
{
    public Sprite[] SpriteValues;

    [SerializeField, Range(0, 5)] private int[] _hitPoints;
    [SerializeField, Range(0, 5)] private int[] damage;
    [SerializeField, Range(0, 5)] private int[] _speed;

    public Sprite[] GetValues(int index)
    {
        if (index < 0 || index >= _hitPoints.Length || index >= damage.Length || index >= _speed.Length)
        {
            Debug.LogError("Индекс выходит за пределы массива!");
            return null; 
        }

        Sprite[] values = new Sprite[3];
        values[0] = SpriteValues[_hitPoints[index]];
        values[1] = SpriteValues[damage[index]];
        values[2] = SpriteValues[_speed[index]];

        return values;
    }
}
