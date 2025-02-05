using Windows;

namespace Core.Services.WindowManager
{
    public interface IWindowManager
    {
        TWindow CreateWindow<TWindow>() where TWindow : BaseWindow;
        void LoadWindows();
    }
}