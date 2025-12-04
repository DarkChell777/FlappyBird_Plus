using UnityEngine;

[CreateAssetMenu(fileName = "Backgrounds", menuName = "Background Skins")]
public class BackgroundSkins : ScriptableObject
{
    [SerializeField] private BackgroundSkin[] _backgrounds;
    public BackgroundSkin[] Backgrounds => _backgrounds;
}

[System.Serializable]
public class BackgroundSkin
{
    public BackgroundSkinType skin;
    public Sprite gameSprite;
    public Sprite shopSprite;
    public AudioClip ambiend;
    [Min(0)] public int price;
    public bool dontSale;
    public Sprite ground;
    public bool isGroundAnimSpeed;
    public string About;
}

public enum BackgroundSkinType
{
    Zamok,
    ZelenieGori,
    Jungle,
    Magma,
    Kosmos,
}
