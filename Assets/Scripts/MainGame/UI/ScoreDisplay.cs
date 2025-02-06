using MainGame.Balloons;
using TMPro;
using UnityEngine;
using Zenject;

namespace MainGame.UI
{
    public class ScoreDisplay
    {
        private readonly TMP_Text _scoreText;
        private readonly BalloonPopper _balloonPopper;

        [Inject]
        public ScoreDisplay(TMP_Text scoreText, BalloonPopper balloonPopper)
        {
            _scoreText = scoreText;
            _balloonPopper = balloonPopper;
        }

        public void Init()
        {
            UpdateText();

            _balloonPopper.OnBalloonPopped += UpdateText;
        }

        public void DeInit()
        {
            _balloonPopper.OnBalloonPopped -= UpdateText;
        }

        private void UpdateText()
        {
            _scoreText.text = _balloonPopper.BalloonCount.ToString();
        }
    }
}
