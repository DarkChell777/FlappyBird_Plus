using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    private void Start()
    {
        foreach (var obj in gameObjects)
        {
            obj.SetActive(false);
        }
    }
}
