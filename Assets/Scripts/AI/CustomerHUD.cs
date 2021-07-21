using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomerHUD : MonoBehaviour
{
    [SerializeField]
    Image _fillingBar;

    private void Start()
    {
        _fillingBar.fillAmount = 0;
    }
    public void FillProgressBar(float value)
    {
        _fillingBar.fillAmount = value;
    }

}
