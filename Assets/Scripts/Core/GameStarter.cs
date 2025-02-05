﻿using Core.Services.SaveLoadService;
using Core.Services.SceneLoader;
using Core.Services.WindowManager;
using Zenject;

namespace Core
{
    public class GameStarter : IInitializable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IWindowManager _windowManager;
        
        [Inject]
        public GameStarter(SceneLoader sceneLoader, ISaveLoadService saveLoadService, IWindowManager windowManager)
        {
            _sceneLoader = sceneLoader;
            _saveLoadService = saveLoadService;
            _windowManager = windowManager;
        }

        public void Initialize()
        {
            _saveLoadService.Load();
            _windowManager.LoadWindows();
            
            _sceneLoader.LoadScene(SceneName.MainMenu);
        }
    }
}