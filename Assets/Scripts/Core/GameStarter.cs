using Core.Services.SceneLoader;
using Zenject;

namespace Core
{
    public class GameStarter : IInitializable
    {
        private readonly SceneLoader _sceneLoader;
        
        [Inject]
        public GameStarter(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _sceneLoader.LoadScene(SceneName.MainMenu);
        }
    }
}