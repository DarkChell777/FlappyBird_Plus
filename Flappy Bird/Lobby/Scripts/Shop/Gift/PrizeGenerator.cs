using System;
using System.Collections.Generic;
using UnityEngine;

public class PrizeGenerator : MonoBehaviour
{
    [SerializeField] private ConfigsController _controller;
    [SerializeField] private PrizeManager _manager;
    [SerializeField] private PlayerSkins _playerSkins;
    [SerializeField] private BackgroundSkins _backgroundSkins;
    [SerializeField] private Probabillity[] _probabillity;

    private List<object> _skinsList = new List<object>();

    private void OnValidate()
    {
        float numbersSum = 0;

        foreach (var num in _probabillity)
        {
            numbersSum += num.piecentWin;

            if (numbersSum > 100)
            {
                num.piecentWin -= (float)Math.Round(numbersSum - 100, 2);
            }
        }
    }

    private void UpdateHasSkinsList()
    {
        _skinsList.Clear();

        foreach (var sk in _playerSkins.Characters)
        {
            if (_controller.IsPSkinUnlocked(sk.skin)) continue;

            _skinsList.Add(sk);
        }

        foreach (var sk in _backgroundSkins.Backgrounds)
        {
            if (_controller.IsBSkinUnlocked(sk.skin)) continue;
            
            _skinsList.Add(sk);
        }
    }

    public void Generate()
    {
        UpdateHasSkinsList();

        float randomValue = UnityEngine.Random.Range(0.00f, 100.00f);
        
        float cumulativeProbability = 0;

        for (int i = 0; i < _probabillity.Length; i++)
        {
            cumulativeProbability += _probabillity[i].piecentWin;

            if (randomValue <= cumulativeProbability)
            {
               PrizeType selectedPrizeType = _probabillity[i].type;

               if (selectedPrizeType == PrizeType.Money || _skinsList.Count == 0)
                {
                   int amountOfMoney = UnityEngine.Random.Range(1, 10);
                   _manager.SetPrize(amountOfMoney);
                }

               else if (selectedPrizeType == PrizeType.Skin)
               {
                    int randomIndex = UnityEngine.Random.Range(0, _skinsList.Count);
                    object selectedSkin = _skinsList[randomIndex];

                    _manager.SetPrize(selectedSkin);
                }
                break;
            }
        }
    }



    [Serializable, HideInInspector]
    public class Probabillity
    {
        public PrizeType type;
        [Range(0, 100)] public float piecentWin = 0.00f;
    }
}
