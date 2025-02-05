using Core.Factories.GameFactory;
using MainGame.Balloons;
using MainGame.GameField;
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
            Container.Bind<BalloonSpawner>().AsSingle().WithArguments(mainGameField.SpawnRange);

            Container.BindInterfacesTo<MainGameManager>().AsSingle();
        }
    }
}