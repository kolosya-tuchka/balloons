using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace MainGame.Balloons
{
    public class BalloonMover
    {
        private readonly BalloonSpawner _balloonSpawner;
        private readonly Dictionary<Balloon, Tween> _balloonTweens;
        
        [Inject]
        public BalloonMover(BalloonSpawner balloonSpawner)
        {
            _balloonSpawner = balloonSpawner;
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
            Sequence balloonSequence = DOTween.Sequence();
            balloonSequence.Append(balloon.transform.DOMoveY(balloon.transform.position.y + 20, 5)
                .SetEase(Ease.Linear));

            balloonSequence.Join(balloon.transform.DOLocalMoveX(balloon.transform.localPosition.x + 0.1f, 0.5f)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo));

            //balloonSequence.SetLoops(-1, LoopType.Restart);

            _balloonTweens[balloon] = balloonSequence;
        }

        private void OnBalloonDespawned(Balloon balloon)
        {
            _balloonTweens[balloon].Kill();
        }
    }
}