using MainMenu;
using Zenject;

namespace Core.Factories.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _container;

        [Inject]
        public GameFactory(DiContainer container)
        {
            _container = container;
        }

        public MainMenuUI CreateMainMenuUI() =>
            _container.InstantiatePrefabResource(ResourcePaths.MainMenuUI).GetComponent<MainMenuUI>();
    }
}