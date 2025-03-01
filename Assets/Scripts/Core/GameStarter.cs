﻿using Core.Services.AudioService;
using Core.Services.ConfigProvider;
using Core.Services.SaveLoadService;
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
        private readonly IAudioService _audioService;
        
        [Inject]
        public GameStarter(SceneLoader sceneLoader, ISaveLoadService saveLoadService, IWindowManager windowManager,
            IAudioService audioService)
        {
            _sceneLoader = sceneLoader;
            _saveLoadService = saveLoadService;
            _windowManager = windowManager;
            _audioService = audioService;
        }

        public void Initialize()
        {
            _saveLoadService.Load();
            _windowManager.LoadWindows();
            _audioService.PlayMusic();
            
            _sceneLoader.LoadScene(SceneName.MainMenu);
        }
    }
}