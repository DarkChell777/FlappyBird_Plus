using UnityEngine;

[RequireComponent(typeof(GroundSeter))]
public class BackgroundSeter : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GroundSeter _groundSeter;
    [SerializeField] private Transform _background;
    [SerializeField] private BackgroundSkins _skins;

    public void SetSkin(int skinIndex)
    {
        _background.GetComponent<SpriteRenderer>().sprite = _skins.Backgrounds[skinIndex].gameSprite;
        _background.transform.SetParent(_background);
        _background.gameObject.SetActive(true);

        _groundSeter.SetGround(skinIndex);

        _audioManager.SetMusic(skinIndex);
    }

    
}
