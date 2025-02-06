﻿using Core.Services.SaveLoadService;
using Core.Services.SceneLoader;
using MainGame.Balloons;
using MainGame.GameField;
using MainGame.GameLoop;
using Zenject;

namespace Core
{
    public class MainGameManager : IInitializable
    {
        private readonly BalloonSpawner _balloonSpawner;
        private readonly MainGameField _mainGameField;
        private readonly BalloonMover _balloonMover;
        private readonly BalloonPopper _balloonPopper;
        private readonly GameOverController _gameOverController;
        private readonly ISaveLoadService _saveLoadService;
        private readonly SceneLoader _sceneLoader;

        [Inject]
        public MainGameManager(BalloonSpawner balloonSpawner, MainGameField mainGameField, SceneLoader sceneLoader,
            BalloonMover balloonMover, BalloonPopper balloonPopper, GameOverController gameOverController,
            ISaveLoadService saveLoadService)
        {
            _balloonSpawner = balloonSpawner;
            _mainGameField = mainGameField;
            _balloonMover = balloonMover;
            _balloonPopper = balloonPopper;
            _gameOverController = gameOverController;
            _saveLoadService = saveLoadService;
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _balloonMover.Init();
            _balloonPopper.Init();
            _gameOverController.Init(RestartGame, GoToMainMenu);
            
            StartGameplay();
        }

        private void StartGameplay()
        {
            _balloonSpawner.StartGameplay();
        }

        private void DeInit()
        {
            _balloonMover.DeInit();
            _balloonPopper.DeInit();
            _gameOverController.DeInit();
            _balloonSpawner.DeInit();
        }

        private void Save(string name)
        {
            _saveLoadService.Save(new(name, _balloonPopper.BalloonCount));
        }

        private void RestartGame(string name)
        {
            DeInit();
            Save(name);
            
            _sceneLoader.LoadScene(SceneName.MainGame);
        }

        private void GoToMainMenu(string name)
        {
            DeInit();
            Save(name);
            
            _sceneLoader.LoadScene(SceneName.MainMenu);
        }
    }
}