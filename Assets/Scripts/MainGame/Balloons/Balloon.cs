using System;
using UnityEngine;

namespace MainGame.Balloons
{
    public class Balloon : MonoBehaviour
    {
        private Action<Balloon> _onBalloonDespawn;
        
        public void Init(Action<Balloon> onBalloonDespawn)
        {
            _onBalloonDespawn = onBalloonDespawn;
        }

        public void Despawn()
        {
            Debug.Log("Despawn");
            _onBalloonDespawn?.Invoke(this);
        }
    }
}