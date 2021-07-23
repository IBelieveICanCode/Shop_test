using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ShoppingGame.Customer;

namespace ShoppingGame
{
    public class GameAdministration : MonoBehaviour
    {
        [Inject]
        readonly GameConfig _config;
        [Inject]
        readonly ConsumerModel.CustomerFactory _customerFactory;
        [Inject]
        readonly Environment _env;

        [SerializeField]
        int _numPeople = 20;

        private void Start()
        {
            for (int i = 0; i < _numPeople; i++)
                _customerFactory.Create(_env.GetStartingPoint().position, _config.ConsumerSettings);
        }
    }
}


