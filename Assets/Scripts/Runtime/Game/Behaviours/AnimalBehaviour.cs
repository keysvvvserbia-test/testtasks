using System;
using UnityEngine;
using Zenject;
using ZooWorld.Animals;
using ZooWorld.Animals.Movement;
using ZooWorld.CollisionResolver;
using ZooWorld.Foundation;
using ZooWorld.Game.Behaviours.Config;

namespace ZooWorld.Game.Behaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class AnimalBehaviour : BaseAutoInjectableMonoComponent, IAnimal
    {
        private ICollisionResolver _collisionResolver;
        private IAnimalRegistry _registry;

        private DietType _diet;
        private IMovementStrategy _movementStrategy;
        private bool _alive = true;
        private Action<string, AnimalBehaviour> _despawnCallback;
        private AnimalConfig _config;
        private Vector3 _spawnPosition;
        private Quaternion _spawnRotation;

        public DietType Diet => _diet;
        public bool IsAlive => _alive;
        public Transform Transform => transform;

        [Inject]
        private void Resolve(ICollisionResolver collisionResolver, IAnimalRegistry registry)
        {
            _collisionResolver = collisionResolver;
            _registry = registry;
        }

        private void OnEnable()
        {
            if (_alive)
                return;

            transform.localPosition = _spawnPosition;
            transform.localRotation = _spawnRotation;
            _alive = true;
        }

        private void Update()
        {
            if (!_alive)
                return;

            var dt = Time.deltaTime;
            _movementStrategy?.Move(transform, dt);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_alive)
                return;

            var otherAnimal = other.gameObject.GetComponent<AnimalBehaviour>();
            if (otherAnimal != null && otherAnimal.IsAlive)
            {
                _collisionResolver.Resolve(this, otherAnimal);
            }
        }

        public void Initialize(Vector3 position,
            Quaternion rotation,
            AnimalConfig config,
            Action<string, AnimalBehaviour> despawnCallback)
        {
            _alive = false;
            _config = config;
            _diet = config.Diet;
            _movementStrategy = config.CreateMovementStrategy();
            _despawnCallback = despawnCallback;
            _spawnPosition = position;
            _spawnRotation = rotation;
            _registry.RegisterAlive(this);

            gameObject.SetActive(true);
        }

        public void Die()
        {
            if (!_alive)
                return;

            _alive = false;
            _registry.UnregisterAndCountDeath(this);

            if (_despawnCallback != null)
            {
                _despawnCallback(_config.Id, this);
                return;
            }

            Destroy(gameObject);
        }

        public void Kill()
        {
            if (!_alive)
                return;

            Debug.Log("Kill!!");
        }

        public void Collision()
        {
            if (!_alive)
                return;

            _movementStrategy.Move(transform, 1f);
            Debug.Log("Collision!!");
        }
    }
}
