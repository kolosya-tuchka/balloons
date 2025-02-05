using Core.Factories.GameFactory;
using Core.Services.SaveLoadService;
using Core.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class EntryPointInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner CoroutineRunner;
        
        public override void InstallBindings()
        {
            BindServices();
            BindFactories();

            Container.BindInterfacesTo<CoroutineRunner>().FromInstance(CoroutineRunner).AsSingle();

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
            Container.BindInterfacesTo<PlayerPrefsSaveLoadService>().AsSingle();
        }
    }
}
