using Zenject;

namespace MainGame.Balloons
{
    public class BalloonMover
    {
        private readonly BalloonSpawner _balloonSpawner;

        [Inject]
        public BalloonMover(BalloonSpawner balloonSpawner)
        {
            _balloonSpawner = balloonSpawner;
        }

        public void Init()
        {
            _balloonSpawner.OnBalloonSpawned += OnBalloonSpawned;
        }

        public void DeInit()
        {
            _balloonSpawner.OnBalloonSpawned -= OnBalloonSpawned;
        }

        private void OnBalloonSpawned(BalloonView balloon)
        {
            
        }
    }
}