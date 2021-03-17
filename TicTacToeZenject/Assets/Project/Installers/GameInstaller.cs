using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    GameController gameController;
    [SerializeField]
    GridController gridController;

    public override void InstallBindings()
    {
        Container.Bind<GameController>().FromInstance(gameController).AsSingle().NonLazy();
        Container.Bind<GridController>().FromInstance(gridController).AsSingle().NonLazy();
    }
}