using System;
using Windows.GameOverWindow;
using Core.Services.WindowManager;
using MainGame.Balloons;
using MainGame.GameField;
using Zenject;

namespace MainGame.GameLoop
{
    public class GameOverController
    {
        private readonly BalloonDespawnTrigger _balloonDespawnTrigger;
        private readonly IWindowManager _windowManager;
        
        private Action<string> _onRestart, _onMenu;

        public event Action OnGameOver;

        private bool _gameOver;
        
        [Inject]
        public GameOverController(MainGameField mainGameField, IWindowManager windowManager)
        {
            _windowManager = windowManager;
            _balloonDespawnTrigger = mainGameField.BalloonDespawnTrigger;
        }

        public void Init(Action<string> onRestart, Action<string> onMenu)
        {
            _balloonDespawnTrigger.OnBalloonEnterTrigger += GameOver;

            _onRestart = onRestart;
            _onMenu = onMenu;
        }

        public void DeInit()
        {
            _balloonDespawnTrigger.OnBalloonEnterTrigger -= GameOver;
        }

        private void GameOver(Balloon balloon)
        {
            if (_gameOver)
            {
                return;
            }

            var gameOverWindow = _windowManager.CreateWindow<GameOverWindow>();
            gameOverWindow.Init(_onRestart, _onMenu);
            gameOverWindow.Show();
            
            _gameOver = true;
            OnGameOver?.Invoke();
        }
    }
}