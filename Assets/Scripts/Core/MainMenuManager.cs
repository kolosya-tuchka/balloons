using Windows.RecordsWindow;
using Core.Services.AudioService;
using Core.Services.SaveLoadService;
using Core.Services.SceneLoader;
using Core.Services.WindowManager;
using MainMenu;
using Zenject;

namespace Core
{
    public class MainMenuManager : IInitializable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly MainMenuUI _mainMenuUI;
        private readonly IWindowManager _windowManager;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IAudioService _audioService;
        
        [Inject]
        public MainMenuManager(SceneLoader sceneLoader, MainMenuUI mainMenuUI, IWindowManager windowManager,
            ISaveLoadService saveLoadService, IAudioService audioService)
        {
            _sceneLoader = sceneLoader;
            _mainMenuUI = mainMenuUI;
            _windowManager = windowManager;
            _saveLoadService = saveLoadService;
            _audioService = audioService;
        }

        public void Initialize()
        {
            _mainMenuUI.PlayButton.Init(_audioService, OnPlayButtonClick);
            _mainMenuUI.RecordsButton.Init(_audioService, OnRecordsButtonClick);
        }

        private void DeInit()
        {
            _mainMenuUI.PlayButton.DeInit();
            _mainMenuUI.RecordsButton.DeInit();
        }

        private void OnRecordsButtonClick()
        {
            var recordsWindow = _windowManager.CreateWindow<RecordsWindow>();
            recordsWindow.Init(_saveLoadService.GetRecords(), _audioService);
            recordsWindow.Show();
        }

        private void OnPlayButtonClick()
        {
            DeInit();
            
            _sceneLoader.LoadScene(SceneName.MainGame);
        }
    }
}