using System;
using MainGame.Balloons;
using MainGame.GameField;
using Zenject;

namespace MainGame.GameLoop
{
    public class GameOverController
    {
        private readonly BalloonDespawnTrigger _balloonDespawnTrigger;

        public event Action OnGameOver;

        private bool _gameOver;
        
        [Inject]
        public GameOverController(MainGameField mainGameField)
        {
            _balloonDespawnTrigger = mainGameField.BalloonDespawnTrigger;
        }

        public void Init()
        {
            _balloonDespawnTrigger.OnBalloonEnterTrigger += GameOver;
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
            
            _gameOver = true;
            OnGameOver?.Invoke();
        }
    }
}