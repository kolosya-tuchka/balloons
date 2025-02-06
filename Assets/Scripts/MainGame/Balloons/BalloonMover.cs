using System.Collections.Generic;
using Configs;
using Core.Services.ConfigProvider;
using DG.Tweening;
using MainGame.GameField;
using UnityEngine;
using Zenject;

namespace MainGame.Balloons
{
    public class BalloonMover
    {
        private readonly BalloonSpawner _balloonSpawner;
        private readonly Dictionary<Balloon, Tween> _balloonTweens;
        private readonly MainGameField _mainGameField;
        private readonly BalloonConfig _balloonConfig;
        
        [Inject]
        public BalloonMover(BalloonSpawner balloonSpawner, MainGameField mainGameField, IConfigProvider configProvider)
        {
            _balloonSpawner = balloonSpawner;
            _mainGameField = mainGameField;
            _balloonConfig = configProvider.BalloonConfig;
            _balloonTweens = new(5);
        }

        public void Init()
        {
            _balloonSpawner.OnBalloonSpawned += OnBalloonSpawned;
            _balloonSpawner.OnBalloonDespawned += OnBalloonDespawned;
        }

        public void DeInit()
        {
            _balloonSpawner.OnBalloonSpawned -= OnBalloonSpawned;
            _balloonSpawner.OnBalloonDespawned -= OnBalloonDespawned;
        }

        private void OnBalloonSpawned(Balloon balloon)
        {
            float moveDuration = _mainGameField.FieldHeight / _balloonConfig.BalloonSpeed;
            
            Sequence balloonSequence = DOTween.Sequence();
            balloonSequence.Append(balloon.transform.DOMoveY(
                    balloon.transform.position.y + _mainGameField.FieldHeight,moveDuration)
                .SetEase(Ease.Linear));

            balloonSequence.Join(balloon.transform.DOLocalMoveX(
                    balloon.transform.localPosition.x + _balloonConfig.ShakeStrength, _balloonConfig.ShakeDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo));

            _balloonTweens[balloon] = balloonSequence;
        }

        private void OnBalloonDespawned(Balloon balloon)
        {
            _balloonTweens[balloon].Kill();
        }
    }
}