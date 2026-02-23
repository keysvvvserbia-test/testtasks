using System;
using UnityEngine;
using Zenject;
using ZooWorld.Animals;
using ZooWorld.Foundation;
using ZooWorld.Game;

namespace ZooWorld.Installers
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _spawnRoot;
        [SerializeField] private AnimalConfig[] _animalConfigs;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AnimalRegistry>().AsSingle();
            Container.BindInterfacesTo<CollisionResolver.CollisionResolver>().AsSingle();

            Transform root = _spawnRoot != null ? _spawnRoot : new GameObject("Animals").transform;
            AnimalConfig[] configs = _animalConfigs is { Length: > 0 } 
                ? _animalConfigs 
                : Array.Empty<AnimalConfig>();
            
            Container.Bind<IAnimalSpawner>().To<AnimalSpawner>().AsSingle().WithArguments(configs, root);
            Container.BindInterfacesTo<GameBootstrap>().AsSingle();

            SceneContextResolver.Container = Container;
            SceneContextResolver.ContextInstance = gameObject;
        }
    }
}
