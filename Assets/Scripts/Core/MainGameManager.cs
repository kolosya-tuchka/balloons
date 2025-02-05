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
        private readonly BalloonMover _balloonMover;
        private readonly BalloonPopper _balloonPopper;
        private readonly SceneLoader _sceneLoader;

        [Inject]
        public MainGameManager(BalloonSpawner balloonSpawner, MainGameField mainGameField, SceneLoader sceneLoader,
            BalloonMover balloonMover, BalloonPopper balloonPopper)
        {
            _balloonSpawner = balloonSpawner;
            _mainGameField = mainGameField;
            _balloonMover = balloonMover;
            _balloonPopper = balloonPopper;
        }

        public void Initialize()
        {
            _balloonMover.Init();
            _balloonPopper.Init();
            
            StartGameplay();
        }

        private void StartGameplay()
        {
            _balloonSpawner.StartGameplay();
        }

        private void DeInit()
        {
            _balloonMover.DeInit();
            _balloonPopper.DeInit();
            
            _sceneLoader.LoadScene(SceneName.MainMenu);
        }
    }
}