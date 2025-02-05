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
        private readonly IGameFactory _gameFactory;
        private readonly MainGameField _mainGameField;

        private bool _spawn;
        
        [Inject]
        public BalloonSpawner(ICoroutineRunner coroutineRunner, IGameFactory gameFactory, MainGameField mainGameField)
        {
            _coroutineRunner = coroutineRunner;
            _spawnRange = mainGameField.SpawnRange;
            _mainGameField = mainGameField;
            _gameFactory = gameFactory;
            _balloonPool = new ObjectPool<Balloon>(FactoryMethod);
        }

        public void StartGameplay()
        {
            _spawn = true;
            _coroutineRunner.StartCoroutine(SpawnCoroutine());
        }

        public void DeInit()
        {
            _spawn = false;
        }

        private IEnumerator SpawnCoroutine()
        {
            while (_spawn)
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

        private Balloon FactoryMethod()
        {
            var balloon = _gameFactory.CreateBalloon();
            balloon.gameObject.SetActive(false);
            balloon.Init(DespawnBalloon);
            balloon.transform.parent = _mainGameField.BalloonsParent;
            return balloon;
        }
    }
}