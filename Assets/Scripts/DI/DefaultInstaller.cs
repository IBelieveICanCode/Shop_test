using Zenject;
using UnityEngine;

public class DefaultInstaller : MonoInstaller
{
    [Inject]
    private readonly GameConfig config;
    public override void InstallBindings()
    {
        Container.BindFactory<Vector3, CustomerModel, CustomerModel.CustomerFactory>()
            .FromComponentInNewPrefab(config.ConsumerPrefab)
            .WithGameObjectName("Consumer");

        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GivePlayerPointsSignal>();
    }
}