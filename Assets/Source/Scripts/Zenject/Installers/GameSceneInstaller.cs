using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ArmyManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BetManager>().FromComponentInHierarchy().AsSingle();
        
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GameEndedSignal>();
        Container.DeclareSignal<GameStartSignal>();
    }
}
