using Core.Services.SaveLoadService;
using Core.Services.SceneLoader;
using Zenject;

namespace Core
{
    public class GameStarter : IInitializable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ISaveLoadService _saveLoadService;
        
        [Inject]
        public GameStarter(SceneLoader sceneLoader, ISaveLoadService saveLoadService)
        {
            _sceneLoader = sceneLoader;
            _saveLoadService = saveLoadService;
        }

        public void Initialize()
        {
            _saveLoadService.Load();
            
            _sceneLoader.LoadScene(SceneName.MainMenu);
        }
    }
}