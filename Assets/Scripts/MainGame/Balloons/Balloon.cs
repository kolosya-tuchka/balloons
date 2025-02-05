using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainGame.Balloons
{
    public class Balloon : MonoBehaviour, IPointerDownHandler
    {
        public event Action<Balloon> OnBalloonClick; 
        
        private Action<Balloon> _onBalloonDespawn;
        
        public void Init(Action<Balloon> onBalloonDespawn)
        {
            _onBalloonDespawn = onBalloonDespawn;
        }

        public void Despawn()
        {
            _onBalloonDespawn?.Invoke(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnBalloonClick?.Invoke(this);
        }
    }
}