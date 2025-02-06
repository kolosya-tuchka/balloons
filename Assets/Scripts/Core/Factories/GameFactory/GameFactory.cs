using Core.Services.ResourceProvider;
using MainGame.Balloons;
using MainGame.GameField;
using MainGame.UI;
using MainMenu;
using UnityEngine;
using Zenject;

namespace Core.Factories.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IResourceProvider _resourceProvider;

        [Inject]
        public GameFactory(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }

        public MainMenuUI CreateMainMenuUI() =>
            _resourceProvider.LoadAndInstantiate(ResourcePaths.MainMenuUI).GetComponent<MainMenuUI>();

        public MainGameUI CreateMainGameUI() =>
            _resourceProvider.LoadAndInstantiate(ResourcePaths.MainGameUI).GetComponent<MainGameUI>();

        public MainGameField CreateMainGameField() =>
            _resourceProvider.LoadAndInstantiate(ResourcePaths.MainGameField).GetComponent<MainGameField>();

        public Balloon CreateBalloon(Transform parent) =>
            _resourceProvider.LoadAndInstantiate(ResourcePaths.Balloon, parent).GetComponent<Balloon>();
    }
}