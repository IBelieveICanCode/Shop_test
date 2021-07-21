using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
{
    [SerializeField]
    GameConfig _gameConfig;
    public override void InstallBindings()
    {
        Container.BindInstances(_gameConfig);
    }
}