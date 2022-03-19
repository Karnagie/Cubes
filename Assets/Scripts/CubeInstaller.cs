using CubeEssence;
using CubeEssence.CubeFXEssence;
using UnityEngine;
using Zenject;

public class CubeInstaller : MonoInstaller
{
    [SerializeField] private CubeSpawner[] _spawners;
    
    public override void InstallBindings()
    {
        InstallCubeSpawners();
        InstallFX();
    }

    private void InstallFX()
    {
        Container.Bind<ICubeFX>().To<DefaultCubeFX>().AsTransient();
    }

    private void InstallCubeSpawners()
    {
        Container.Bind<CubeSpawner[]>().FromInstance(_spawners);
    }
}