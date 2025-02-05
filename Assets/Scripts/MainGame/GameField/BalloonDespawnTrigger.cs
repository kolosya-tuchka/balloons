using System;
using MainGame.Balloons;
using UnityEngine;

namespace MainGame.GameField
{
    public class BalloonDespawnTrigger : MonoBehaviour
    {
        private Action<BalloonView> _onBalloonEnterTrigger;

        public void Init(Action<BalloonView> onBalloonEnterTrigger)
        {
            _onBalloonEnterTrigger = onBalloonEnterTrigger;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BalloonView balloon))
            {
                _onBalloonEnterTrigger?.Invoke(balloon);
            }
        }
    }
}