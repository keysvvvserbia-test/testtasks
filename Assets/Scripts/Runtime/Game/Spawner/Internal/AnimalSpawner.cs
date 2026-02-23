using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using ZooWorld.Game.Behaviours;
using ZooWorld.Game.Behaviours.Config;
using Random = UnityEngine.Random;

namespace ZooWorld.Game
{
    public sealed class AnimalSpawner : IAnimalSpawner
    {
        private readonly Vector2 _spawnRange;

        private readonly AnimalFactory _factory;
        private readonly AnimalConfig[] _configs;
        private readonly System.Random _random = new();

        private bool _running;

        [Inject]
        public AnimalSpawner(
            AnimalConfig[] configs,
            IFieldManager fieldManager,
            Transform spawnRoot)
        {
            _configs = configs;
            _factory = new AnimalFactory(spawnRoot);
            var fieldSize = fieldManager.Size;
            _spawnRange = new Vector2(fieldSize.x * 0.4f, fieldSize.y * 0.4f);
        }

        public void StartSpawning()
        {
            _running = true;
            SpawnLoop().Forget();
        }

        public void StopSpawning()
        {
            _running = false;
        }

        private async UniTaskVoid SpawnLoop()
        {
            while (_running && _configs is { Length: > 0 })
            {
                var delay = 1f + (float)_random.NextDouble(); // 1–2 seconds
                await UniTask.Delay(TimeSpan.FromSeconds(delay), ignoreTimeScale: false);

                if (!_running)
                    break;

                var config = _configs[_random.Next(_configs.Length)];
                Spawn(config);
            }
        }

        private void Spawn(AnimalConfig config)
        {
            var behaviour = _factory.Spawn(config.Id, config.Original);
            if (behaviour == null)
                throw new NullReferenceException($"Can't spawn animal {config.Id}");

            behaviour.Initialize(GetSpawnPosition(), Quaternion.identity, config, Despawn);
        }

        private void Despawn(string id, AnimalBehaviour behaviour)
        {
            _factory.Retrieve(behaviour, id);
        }

        private Vector3 GetSpawnPosition()
        {
            var x = Random.Range(-_spawnRange.x, _spawnRange.x);
            var z = Random.Range(-_spawnRange.y, _spawnRange.y);
            return new Vector3(x, 0f, z);
        }
    }
}
