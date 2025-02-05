using Zenject;

namespace MainGame.Balloons
{
    public class BalloonPopper
    {
        private readonly BalloonSpawner _balloonSpawner;

        public int BalloonCount { get; private set; }
        
        [Inject]
        public BalloonPopper(BalloonSpawner balloonSpawner)
        {
            _balloonSpawner = balloonSpawner;
        }

        public void Init()
        {
            _balloonSpawner.OnBalloonSpawned += LinkBalloon;
        }

        public void DeInit()
        {
            _balloonSpawner.OnBalloonSpawned -= LinkBalloon;
        }

        private void LinkBalloon(Balloon balloon)
        {
            balloon.OnBalloonClick += PopBalloon;
        }

        private void PopBalloon(Balloon balloon)
        {
            ++BalloonCount;
            balloon.Despawn();
            balloon.OnBalloonClick -= PopBalloon;
        }
    }
}