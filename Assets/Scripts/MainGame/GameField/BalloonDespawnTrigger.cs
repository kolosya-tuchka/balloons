using System;
using MainGame.Balloons;
using UnityEngine;

namespace MainGame.GameField
{
    public class BalloonDespawnTrigger : MonoBehaviour
    {
        public event Action<BalloonView> OnBalloonEnterTrigger;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BalloonView balloon))
            {
                OnBalloonEnterTrigger?.Invoke(balloon);
            }
        }
    }
}