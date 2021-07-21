using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameAdministration : MonoBehaviour
{
    [Inject]
   readonly CustomerModel.CustomerFactory _customerPool;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
            _customerPool.Create(Vector3.zero);
    }
}
