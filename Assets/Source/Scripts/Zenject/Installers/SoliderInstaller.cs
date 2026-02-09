using Zenject;

public class SoliderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISolider>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
