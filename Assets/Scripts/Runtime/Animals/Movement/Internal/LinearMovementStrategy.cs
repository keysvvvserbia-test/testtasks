using UnityEngine;
using ZooWorld.Foundation;

namespace ZooWorld.Animals.Movement
{
    public sealed class LinearMovementStrategy : IMovementStrategy
    {
        private readonly float _unitsPerSecond;
        private readonly float _directionChangeInterval;

        private float _directionTimer;
        private Vector3 _currentDirection;

        public LinearMovementStrategy(float unitsPerSecond, float directionChangeInterval)
        {
            _unitsPerSecond = unitsPerSecond;
            _directionChangeInterval = directionChangeInterval;
            _directionTimer = directionChangeInterval;
        }

        public void Tick(IAnimal animal, float deltaTime)
        {
            if (!animal.IsAlive)
                return;

            _directionTimer += deltaTime;
            if (_directionTimer >= _directionChangeInterval)
            {
                ChangeDirection();
                _directionTimer = 0f;
            }
            
            var move = _currentDirection * (_unitsPerSecond * deltaTime);
            this.MoveTowards(animal.Transform, move);
        }

        private void ChangeDirection()
        {
            var x = Random.Range(-1f, 1f);
            var z = Random.Range(-1f, 1f);
            _currentDirection = new Vector3(x, 0f, z);
            if (_currentDirection.sqrMagnitude < 0.01f)
            {
                _currentDirection = Vector3.forward;
            }
            _currentDirection.Normalize();
        }
    }
}
