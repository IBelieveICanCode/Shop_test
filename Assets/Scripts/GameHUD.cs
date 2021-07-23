using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

namespace ShoppingGame.HUD
{
    public class GameHUD : MonoBehaviour
    {
        [Inject]
        private readonly SignalBus _signalBus;

        private int _totalCoins = 0;
        private int TotalCoins
        {
            get => _totalCoins;
            set
            {
                _totalCoins = value;
                UpdateUI();
            }
        }

        [SerializeField]
        TMP_Text _totalCoinsText;


        private void Start()
        {
            _signalBus.Subscribe<GivePlayerCoinsSignal>(x => AddCoins(x.Coins));
            _signalBus.Subscribe<LoadSaveObjectSignal>(x => LoadScores(x.SaveObject));
        }

        void AddCoins(int scores)
        {
            TotalCoins += scores;
        }

        void UpdateUI()
        {
            _totalCoinsText.text = TotalCoins.ToString();
        }

        void LoadScores(SaveSpace.SaveObject saveObject)
        {
            TotalCoins = saveObject.Coins;
        }
    }
}
