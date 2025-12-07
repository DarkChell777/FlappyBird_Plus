using UnityEngine;

[CreateAssetMenu(fileName = "Players", menuName = "Player Skins")]
public class PlayerSkins : ScriptableObject
{
    [SerializeField] private PlayerSkin[] _charackters;
    public PlayerSkin[] Characters => _charackters;
}

[System.Serializable]
public class PlayerSkin
{
    public PlayerSkinType skin;
    public Sprite sprite;
    public AudioClip sound;
    [Min(0)] public int price;
    public bool dontSale;
    public PlayerCharactiristiks charactiristiks;
    public string About;
}

[System.Serializable]
public class PlayerCharactiristiks 
{
    [Range(0, 5)] public int health;
    [Range(0, 5)] public int damage;
    [Range(0, 5)] public int mobility;
}

public enum PlayerSkinType
{
    Golub,
    Vorona,
    Ptenetz,
    Orel,
}
