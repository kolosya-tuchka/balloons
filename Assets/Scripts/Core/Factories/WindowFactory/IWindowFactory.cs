using Windows.GameOverWindow;
using Windows.RecordsWindow;

namespace Core.Factories.WindowFactory
{
    public interface IWindowFactory
    {
        GameOverWindow CreateGameOverWindow();
        RecordsWindow CreateRecordsWindow();
    }
}