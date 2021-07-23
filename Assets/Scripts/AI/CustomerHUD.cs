using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShoppingGame.Customer
{
    public class CustomerHUD : MonoBehaviour
    {
        [SerializeField]
        Image _fillingBar;

        [Inject]
        readonly ICameraPosition _camera;

        private void Start() => _fillingBar.fillAmount = 0;
        private void Update() => _fillingBar.transform.LookAt(_fillingBar.transform.position + _camera.Rotation * Vector3.back, 
            _camera.Rotation  * Vector3.up);

        public void FillProgressBar(float value) => _fillingBar.fillAmount = value;

    }
}
