using Core.Factories.GameFactory;
using Core.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class EntryPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
            BindFactories();

            StartGame();
        }

        private void StartGame()
        {
            Container.BindInterfacesTo<GameStarter>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesTo<GameFactory>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}
