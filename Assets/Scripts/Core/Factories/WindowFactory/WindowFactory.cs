using Windows.GameOverWindow;
using Windows.RecordsWindow;
using Core.Services.ResourceProvider;
using UnityEngine;
using Zenject;

namespace Core.Factories.WindowFactory
{
    public class WindowFactory : IWindowFactory
    {
        private readonly Transform _windowsParent;
        private readonly IResourceProvider _resourceProvider;
        
        [Inject]
        public WindowFactory(Transform windowsParent, IResourceProvider resourceProvider)
        {
            _windowsParent = windowsParent;
            _resourceProvider = resourceProvider;
        }

        public GameOverWindow CreateGameOverWindow() =>
            _resourceProvider.LoadAndInstantiate(WindowPaths.GameOverWindow, _windowsParent).GetComponent<GameOverWindow>();

        public RecordsWindow CreateRecordsWindow() =>
            _resourceProvider.LoadAndInstantiate(WindowPaths.RecordsWindow, _windowsParent).GetComponent<RecordsWindow>();
    }
}