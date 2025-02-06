using Windows.RecordsWindow;
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
        
        [Inject]
        public MainMenuManager(SceneLoader sceneLoader, MainMenuUI mainMenuUI, IWindowManager windowManager,
            ISaveLoadService saveLoadService)
        {
            _sceneLoader = sceneLoader;
            _mainMenuUI = mainMenuUI;
            _windowManager = windowManager;
            _saveLoadService = saveLoadService;
        }

        public void Initialize()
        {
            _mainMenuUI.PlayButton.onClick.AddListener(OnPlayButtonClick);
            _mainMenuUI.RecordsButton.onClick.AddListener(OnRecordsButtonClick);
        }

        private void DeInit()
        {
            _mainMenuUI.PlayButton.onClick.RemoveListener(OnPlayButtonClick);
            _mainMenuUI.RecordsButton.onClick.RemoveListener(OnRecordsButtonClick);
        }

        private void OnRecordsButtonClick()
        {
            var recordsWindow = _windowManager.CreateWindow<RecordsWindow>();
            recordsWindow.Init(_saveLoadService.GetRecords());
            recordsWindow.Show();
        }

        private void OnPlayButtonClick()
        {
            DeInit();
            
            _sceneLoader.LoadScene(SceneName.MainGame);
        }
    }
}