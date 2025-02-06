using System;
using Windows.GameOverWindow;
using Configs;
using Core.Services.AudioService;
using Core.Services.ConfigProvider;
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
        private readonly RecordsConfig _recordsConfig;
        private readonly IAudioService _audioService;
        
        private Action<string> _onRestart, _onMenu;

        public event Action OnGameOver;

        private bool _gameOver;
        
        [Inject]
        public GameOverController(MainGameField mainGameField, IWindowManager windowManager, IConfigProvider configProvider,
            IAudioService audioService)
        {
            _windowManager = windowManager;
            _audioService = audioService;
            _balloonDespawnTrigger = mainGameField.BalloonDespawnTrigger;
            _recordsConfig = configProvider.RecordsConfig;
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

            _audioService.PlaySoundByType(SoundType.Lose);
            
            var gameOverWindow = _windowManager.CreateWindow<GameOverWindow>();
            gameOverWindow.Init(_onRestart, _onMenu, _recordsConfig, _audioService);
            gameOverWindow.Show();
            
            _gameOver = true;
            OnGameOver?.Invoke();
        }
    }
}