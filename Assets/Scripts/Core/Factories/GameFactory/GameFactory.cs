using MainMenu;
using UnityEngine;
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
            LoadAndInstantiate(ResourcePaths.MainMenuUI).GetComponent<MainMenuUI>();

        private GameObject LoadAndInstantiate(string address)
        {
            var prefab = Resources.Load<GameObject>(address);
            return Object.Instantiate(prefab);
        }
    }
}