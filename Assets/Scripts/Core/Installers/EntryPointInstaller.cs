using Core.Factories.GameFactory;
using Core.Factories.WindowFactory;
using Core.Services.ConfigProvider;
using Core.Services.SaveLoadService;
using Core.Services.SceneLoader;
using Core.Services.WindowManager;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class EntryPointInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner CoroutineRunner;
        [SerializeField] private Transform WindowsParent;
        
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
            Container.BindInterfacesTo<WindowFactory>().AsSingle().WithArguments(WindowsParent);
        }

        private void BindServices()
        {
            Container.Bind<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<PlayerPrefsSaveLoadService>().AsSingle();
            Container.BindInterfacesTo<WindowManager>().AsSingle();
            Container.BindInterfacesTo<Services.ResourceProvider.ResourceProvider>().AsSingle();
            Container.BindInterfacesTo<ResourceConfigProvider>().AsSingle();
        }
    }
}
