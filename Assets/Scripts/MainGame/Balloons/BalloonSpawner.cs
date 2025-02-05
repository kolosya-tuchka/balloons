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
        public event Action<Balloon> OnBalloonSpawned, OnBalloonDespawned; 
        
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IObjectPool<Balloon> _balloonPool;
        private readonly SpawnRange _spawnRange;
        
        [Inject]
        public BalloonSpawner(ICoroutineRunner coroutineRunner, IGameFactory gameFactory, SpawnRange spawnRange)
        {
            _coroutineRunner = coroutineRunner;
            _spawnRange = spawnRange;
            _balloonPool = new ObjectPool<Balloon>(() =>
                {
                    var balloon = gameFactory.CreateBalloon();
                    balloon.gameObject.SetActive(false);
                    balloon.Init(DespawnBalloon);
                    return balloon;
                });
        }

        public void StartGameplay()
        {
            _coroutineRunner.StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                SpawnBalloon();
                yield return new WaitForSeconds(1);
            }
        }

        private void SpawnBalloon()
        {
            var balloon = _balloonPool.Get();
            balloon.transform.position = _spawnRange.GetSpawnPoint();
            balloon.gameObject.SetActive(true);
            
            OnBalloonSpawned?.Invoke(balloon);
        }

        private void DespawnBalloon(Balloon balloon)
        {
            balloon.gameObject.SetActive(false);
            _balloonPool.Release(balloon);
            
            OnBalloonDespawned?.Invoke(balloon);
        }
    }
}