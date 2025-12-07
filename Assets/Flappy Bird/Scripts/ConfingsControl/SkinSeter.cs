using UnityEngine;

public class SkinSeter : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;    
    [SerializeField] private SpriteRenderer _bird;
    [SerializeField] private PlayerSkins _skins;

    public void SetSkin(int skinIndex)
    {
        _bird.sprite = _skins.Characters[skinIndex].sprite;

        _audioManager.SetSound(skinIndex);
    }
}
