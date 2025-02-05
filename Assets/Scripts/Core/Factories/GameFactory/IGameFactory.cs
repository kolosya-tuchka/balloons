using MainGame.Balloons;
using MainGame.GameField;
using MainMenu;
using UnityEngine;

namespace Core.Factories.GameFactory
{
    public interface IGameFactory
    {
        MainMenuUI CreateMainMenuUI();
        MainGameField CreateMainGameField();
        Balloon CreateBalloon(Transform parent);
    }
}