using System;
using System.Collections.Generic;
using Windows;
using Core.Factories.GameFactory;
using UnityEngine.UI;
using Zenject;

namespace Core.Services.WindowManager
{
    public class WindowManager : IWindowManager
    {
        private readonly IGameFactory _gameFactory;
        private readonly Dictionary<Type, BaseWindow> _windows = new ();

        [Inject]
        public WindowManager(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public TWindow CreateWindow<TWindow>() where TWindow : BaseWindow =>
            _windows[typeof(TWindow)] as TWindow;

        public void LoadWindows()
        {
            
        }
    }
}