using System;
using System.Collections.Generic;
using Windows;
using Windows.GameOverWindow;
using Windows.RecordsWindow;
using Core.Factories.GameFactory;
using Core.Factories.WindowFactory;
using UnityEngine.UI;
using Zenject;

namespace Core.Services.WindowManager
{
    public class WindowManager : IWindowManager
    {
        private readonly IWindowFactory _windowFactory;
        private readonly Dictionary<Type, BaseWindow> _windows = new ();

        [Inject]
        public WindowManager(IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
        }

        public TWindow CreateWindow<TWindow>() where TWindow : BaseWindow =>
            _windows[typeof(TWindow)] as TWindow;

        public void LoadWindows()
        {
            _windows[typeof(GameOverWindow)] = _windowFactory.CreateGameOverWindow();
            _windows[typeof(RecordsWindow)] = _windowFactory.CreateRecordsWindow();
        }
    }
}