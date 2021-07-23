using Zenject;
using UnityEngine;
using ShoppingGame.Customer;

namespace ShoppingGame
{
    public class DefaultInstaller : MonoInstaller
    {
        [Inject]
        private readonly GameConfig config;

        public override void InstallBindings()
        {
            Container.BindFactory<Vector3, ConsumerSettings, ConsumerModel, ConsumerModel.CustomerFactory>()
                .FromComponentInNewPrefab(config.ConsumerPrefab)
                .WithGameObjectName("Consumer");

            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<GivePlayerCoinsSignal>();
            Container.DeclareSignal<LoadSaveObjectSignal>();
        }
    }
}