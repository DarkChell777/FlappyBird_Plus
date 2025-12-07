using UnityEngine;

public class GroundSeter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _grounds;
    [SerializeField] private BackgroundSkins _skins;

    public void SetGround(int index)
    {
        BackgroundSkin _skin = _skins.Backgrounds[index];

        if (_skin.ground == null) 
        {
            Debug.LogError("ground sprite is null");
        }

        foreach (var ground in _grounds)
        {
            ground.sprite = _skin.ground;
        }
    }
}
