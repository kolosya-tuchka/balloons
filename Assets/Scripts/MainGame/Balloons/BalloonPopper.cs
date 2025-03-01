﻿using System;
using Core.Services.AudioService;
using MainGame.GameLoop;
using Zenject;

namespace MainGame.Balloons
{
    public class BalloonPopper
    {
        public event Action OnBalloonPopped; 
        
        private readonly BalloonSpawner _balloonSpawner;
        private readonly GameOverController _gameOverController;
        private readonly IAudioService _audioService;

        private bool _gameOver;

        public int BalloonCount { get; private set; }
        
        [Inject]
        public BalloonPopper(BalloonSpawner balloonSpawner, GameOverController gameOverController, IAudioService audioService)
        {
            _balloonSpawner = balloonSpawner;
            _gameOverController = gameOverController;
            _audioService = audioService;
        }

        public void Init()
        {
            _balloonSpawner.OnBalloonSpawned += LinkBalloon;
            _gameOverController.OnGameOver += OnGameOver;
        }

        public void DeInit()
        {
            _balloonSpawner.OnBalloonSpawned -= LinkBalloon;
            _gameOverController.OnGameOver -= OnGameOver;
        }

        private void LinkBalloon(Balloon balloon)
        {
            balloon.OnBalloonClick += PopBalloon;
        }

        private void PopBalloon(Balloon balloon)
        {
            if (_gameOver)
            {
                return;
            }
            
            ++BalloonCount;
            _audioService.PlaySoundByType(SoundType.Pop);
            balloon.Despawn();
            balloon.OnBalloonClick -= PopBalloon;
            OnBalloonPopped?.Invoke();
        }

        private void OnGameOver()
        {
            _gameOver = true;
        }
    }
}