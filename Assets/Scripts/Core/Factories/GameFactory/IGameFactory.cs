using MainGame.GameField;
using MainMenu;

namespace Core.Factories.GameFactory
{
    public interface IGameFactory
    {
        MainMenuUI CreateMainMenuUI();
        MainGameField CreateMainGameField();
    }
}