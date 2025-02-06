using System.Collections.Generic;
using Configs;
using Core.Services.ConfigProvider;
using UnityEngine;
using Zenject;

namespace MainGame.Balloons
{
    public class BalloonSkinController
    {
        private readonly BalloonSpawner _balloonSpawner;
        private readonly List<Sprite> _balloonSkins;
        
        [Inject]
        public BalloonSkinController(BalloonSpawner balloonSpawner, IConfigProvider configProvider)
        {
            _balloonSpawner = balloonSpawner;
            _balloonSkins = configProvider.BalloonConfig.BalloonSkins;
        }

        public void Init()
        {
            _balloonSpawner.OnBalloonSpawned += SetupBalloonSkin;
        }

        public void DeInit()
        {
            _balloonSpawner.OnBalloonSpawned -= SetupBalloonSkin;
        }

        private void SetupBalloonSkin(Balloon balloon)
        {
            balloon.GetComponent<SpriteRenderer>().sprite = _balloonSkins[Random.Range(0, _balloonSkins.Count)];
        }
    }
}