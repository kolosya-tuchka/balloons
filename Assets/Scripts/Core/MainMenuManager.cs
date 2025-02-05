using Core.Services.SaveLoadService;
using Core.Services.SceneLoader;
using MainMenu;
using Zenject;

namespace Core
{
    public class MainMenuManager : IInitializable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly MainMenuUI _mainMenuUI;
        
        [Inject]
        public MainMenuManager(SceneLoader sceneLoader, MainMenuUI mainMenuUI)
        {
            _sceneLoader = sceneLoader;
            _mainMenuUI = mainMenuUI;
        }

        public void Initialize()
        {
            _mainMenuUI.PlayButton.onClick.AddListener(OnPlayButtonClick);
        }

        private void OnPlayButtonClick()
        {
            _sceneLoader.LoadScene(SceneName.MainGame);
        }
    }
}