﻿using System;
using MainGame.Balloons;
using UnityEngine;

namespace MainGame.GameField
{
    public class BalloonDespawnTrigger : MonoBehaviour
    {
        public event Action<Balloon> OnBalloonEnterTrigger;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Balloon balloon))
            {
                OnBalloonEnterTrigger?.Invoke(balloon);
                balloon.Despawn();
            }
        }
    }
}