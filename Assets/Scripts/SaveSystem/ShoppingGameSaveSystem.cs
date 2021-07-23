using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ShoppingGame;

namespace SaveSpace
{
    public class ShoppingGameSaveSystem : MonoBehaviour, ISaveControllable
    {
        [Inject]
        readonly SignalBus _signalBus;

        int _coinsToSave = 0;

        void Start()
        {
            _signalBus.Subscribe<GivePlayerCoinsSignal>(x => SetScores(x.Coins));
        }

        public void SetScores(int amount) =>
            _coinsToSave += amount;

        public void Load()
        {
            SaveObject saveObject = SaveSystem.LoadMostRecentObject<SaveObject>(SaveFoldersEnum.ShoppingGame);
            _coinsToSave = saveObject.Coins;
            _signalBus.Fire(new LoadSaveObjectSignal(saveObject));
        }

        public void Save()
        {
            SaveObject saveObject = new SaveObject(_coinsToSave);
            SaveSystem.SaveObject(saveObject, SaveFoldersEnum.ShoppingGame);
        }     
    }

    public class SaveObject
    {
       public int Coins;
       public SaveObject(int coins)
        {
            Coins = coins;
        }
    }
}
