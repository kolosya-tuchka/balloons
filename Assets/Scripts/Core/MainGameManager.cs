using Core.Services.SceneLoader;
using MainGame.Balloons;
using MainGame.GameField;
using Zenject;

namespace Core
{
    public class MainGameManager : IInitializable
    {
        private readonly BalloonSpawner _balloonSpawner;
        private readonly MainGameField _mainGameField;
        private readonly SceneLoader _sceneLoader;

        [Inject]
        public MainGameManager(BalloonSpawner balloonSpawner, MainGameField mainGameField, SceneLoader sceneLoader)
        {
            _balloonSpawner = balloonSpawner;
            _mainGameField = mainGameField;
        }

        public void Initialize()
        {
            _balloonSpawner.Init();
            
            StartGameplay();
        }

        private void StartGameplay()
        {
            _balloonSpawner.StartGameplay();
        }

        private void DeInit()
        {
            _balloonSpawner.DeInit();
            
            _sceneLoader.LoadScene(SceneName.MainMenu);
        }
    }
}