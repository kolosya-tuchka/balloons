using Core.Factories.GameFactory;
using MainMenu;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gameFactory = Container.Resolve<IGameFactory>();
            var mainMenuUI = gameFactory.CreateMainMenuUI();
            Container.Bind<MainMenuUI>().FromInstance(mainMenuUI).AsSingle();
        }
    }
}
