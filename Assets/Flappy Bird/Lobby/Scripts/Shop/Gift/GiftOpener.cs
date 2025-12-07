using UnityEngine;

public class GiftOpener : MonoBehaviour
{
    [SerializeField] private GiftOpeningProcess _opener;
    [SerializeField] private PrizeGenerator _generator;

    public void OpenGift()
    {
        _generator.Generate();
        _opener.Open();
    }
}
