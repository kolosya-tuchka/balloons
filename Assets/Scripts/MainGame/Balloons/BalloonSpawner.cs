using System;
using System.Collections;
using Core;
using Core.Factories.GameFactory;
using MainGame.GameField;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace MainGame.Balloons
{
    public class BalloonSpawner
    {
        public event Action<BalloonView> OnBalloonSpawned; 
        
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IObjectPool<BalloonView> _balloonPool;
        private readonly SpawnRange _spawnRange;
        private readonly BalloonDespawnTrigger _despawnTrigger;
        
        [Inject]
        public BalloonSpawner(ICoroutineRunner coroutineRunner, IGameFactory gameFactory, MainGameField mainGameField)
        {
            _coroutineRunner = coroutineRunner;
            _spawnRange = mainGameField.SpawnRange;
            _despawnTrigger = mainGameField.BalloonDespawnTrigger;
            _balloonPool = new ObjectPool<BalloonView>(() =>
                {
                    var balloon = gameFactory.CreateBalloon();
                    balloon.gameObject.SetActive(false);
                    return balloon;
                }, OnBalloonSpawn,OnBalloonDespawn);
        }

        public void Init()
        {
            _despawnTrigger.OnBalloonEnterTrigger += DespawnBalloon;
        }

        public void DeInit()
        {
            _despawnTrigger.OnBalloonEnterTrigger -= DespawnBalloon;
        }

        public void StartGameplay()
        {
            _coroutineRunner.StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                _balloonPool.Get();
                yield return new WaitForSeconds(1);
            }
        }

        private void OnBalloonSpawn(BalloonView balloon)
        {
            balloon.transform.position = _spawnRange.GetSpawnPoint();
            balloon.gameObject.SetActive(true);
        }

        private void DespawnBalloon(BalloonView balloon)
        {
            _balloonPool.Release(balloon);
        }

        private void OnBalloonDespawn(BalloonView balloon)
        {
            balloon.gameObject.SetActive(false);
        }
    }
}