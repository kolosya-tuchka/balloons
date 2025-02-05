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
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IObjectPool<BalloonView> _balloonPool;
        private readonly SpawnRange _spawnRange;
        
        [Inject]
        public BalloonSpawner(ICoroutineRunner coroutineRunner, IGameFactory gameFactory, SpawnRange spawnRange)
        {
            _coroutineRunner = coroutineRunner;
            _spawnRange = spawnRange;
            _balloonPool = new ObjectPool<BalloonView>(() =>
                {
                    var balloon = gameFactory.CreateBalloon();
                    balloon.gameObject.SetActive(false);
                    return balloon;
                }, OnBalloonSpawned,OnBalloonDespawned);
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

        private void OnBalloonSpawned(BalloonView balloon)
        {
            balloon.transform.position = _spawnRange.GetSpawnPoint();
            balloon.gameObject.SetActive(true);
        }

        private void OnBalloonDespawned(BalloonView balloon)
        {
            balloon.gameObject.SetActive(false);
        }
    }
}