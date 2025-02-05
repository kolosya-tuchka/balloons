using MainGame.Balloons;
using MainGame.GameField;
using Zenject;

namespace Core
{
    public class MainGameManager : IInitializable
    {
        private readonly BalloonSpawner _balloonSpawner;
        private readonly MainGameField _mainGameField;

        [Inject]
        public MainGameManager(BalloonSpawner balloonSpawner, MainGameField mainGameField)
        {
            _balloonSpawner = balloonSpawner;
            _mainGameField = mainGameField;
        }

        public void Initialize()
        {
            
            
            StartGameplay();
        }

        private void StartGameplay()
        {
            _balloonSpawner.StartGameplay();
        }
    }
}