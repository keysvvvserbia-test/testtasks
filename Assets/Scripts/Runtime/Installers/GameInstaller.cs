using System;
using UnityEngine;
using Zenject;
using ZooWorld.Foundation;
using ZooWorld.Game;
using ZooWorld.Game.Behaviours.Config;

namespace ZooWorld.Installers
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform _spawnRoot;
        [SerializeField] private AnimalConfig[] _animalConfigs;
        [SerializeField] private FieldConfig _fieldConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<FieldManager>().AsSingle();
            Container.BindInstance(_fieldConfig).AsSingle().WhenInjectedInto<FieldManager>();
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
