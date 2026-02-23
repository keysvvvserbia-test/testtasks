using UnityEngine;

namespace ZooWorld.Animals.Movement
{
    public sealed class LinearMovementStrategy : IMovementStrategy
    {
        private readonly float _unitsPerSecond;
        private readonly float _directionChangeInterval;
        private readonly Vector2 _fieldSize;

        private float _directionTimer;
        private Vector3 _currentDirection;

        public LinearMovementStrategy(float unitsPerSecond, float directionChangeInterval, Vector2 fieldSize)
        {
            _unitsPerSecond = unitsPerSecond;
            _directionChangeInterval = directionChangeInterval;
            _directionTimer = directionChangeInterval;
            _fieldSize = fieldSize;
        }

        public void Move(Transform transform, float deltaTime)
        {
            _directionTimer += deltaTime;
            if (_directionTimer >= _directionChangeInterval)
            {
                ChangeDirection();
                _directionTimer = 0f;
            }

            var move = _currentDirection * (_unitsPerSecond * deltaTime);
            this.MoveTowards(transform, move, _fieldSize);
        }

        private void ChangeDirection()
        {
            _currentDirection = this.GetRandomDirectionXZ();

            if (_currentDirection.sqrMagnitude < 0.01f)
            {
                _currentDirection = Vector3.forward;
            }

            _currentDirection.Normalize();
        }
    }
}
