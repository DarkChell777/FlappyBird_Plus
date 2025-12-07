using UnityEngine;

public class GameModeSeter : MonoBehaviour
{
    public int currentMode { get; private set; }
    
    public void SetGameMode(int mode)
    {
        currentMode = mode;
    }
}
