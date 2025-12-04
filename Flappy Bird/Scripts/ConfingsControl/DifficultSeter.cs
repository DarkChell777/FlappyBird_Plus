using System;
using UnityEngine;

public class DifficultSeter : MonoBehaviour
{
    public event Action<int> DifficultSetting;

    public void SetDifficult(int difficult)
    {
        difficult--;
        DifficultSetting?.Invoke(difficult);
    }
}
