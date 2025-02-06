using MainGame.Balloons;
using MainGame.GameField;
using MainGame.UI;
using MainMenu;
using UnityEngine;

namespace Core.Factories.GameFactory
{
    public interface IGameFactory
    {
        MainMenuUI CreateMainMenuUI();
        MainGameUI CreateMainGameUI();
        MainGameField CreateMainGameField();
        Balloon CreateBalloon(Transform parent);
    }
}