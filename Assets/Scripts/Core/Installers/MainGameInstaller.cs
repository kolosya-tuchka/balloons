using Core.Factories.GameFactory;
using MainGame.Balloons;
using MainGame.GameField;
using MainGame.GameLoop;
using MainGame.UI;
using Zenject;

namespace Core.Installers
{
    public class MainGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gameFactory = Container.Resolve<IGameFactory>();
            var mainGameField = gameFactory.CreateMainGameField();
            Container.Bind<MainGameField>().FromInstance(mainGameField).AsSingle();
            Container.Bind<BalloonSpawner>().AsSingle();
            Container.Bind<BalloonMover>().AsSingle();
            Container.Bind<BalloonPopper>().AsSingle();
            Container.Bind<GameOverController>().AsSingle();
            Container.Bind<BalloonSkinController>().AsSingle();

            var mainGameUI = gameFactory.CreateMainGameUI();
            Container.Bind<MainGameUI>().FromInstance(mainGameUI).AsSingle();
            Container.Bind<ScoreDisplay>().AsSingle().WithArguments(mainGameUI.ScoreText);

            Container.BindInterfacesTo<MainGameManager>().AsSingle();
        }
    }
}