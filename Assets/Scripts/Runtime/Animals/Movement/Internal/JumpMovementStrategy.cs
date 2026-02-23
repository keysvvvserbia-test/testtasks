using UnityEngine;

namespace ZooWorld.Animals.Movement
{
    public sealed class JumpMovementStrategy : IMovementStrategy
    {
        private readonly float _intervalSeconds;
        private readonly float _jumpDistance;
        private readonly Vector2 _fieldSize;

        private float _timer;

        public JumpMovementStrategy(float intervalSeconds, float jumpDistance, Vector2 fieldSize)
        {
            _intervalSeconds = intervalSeconds;
            _jumpDistance = jumpDistance;
            _fieldSize = fieldSize;
        }

        public void Move(Transform transform, float deltaTime)
        {
            _timer += deltaTime;
            if (!(_timer >= _intervalSeconds))
                return;

            _timer = 0f;
            var dir = this.GetRandomDirectionXZ();
            if (dir.sqrMagnitude < 0.01f)
            {
                dir = Vector3.forward;
            }

            dir.Normalize();

            var jump = dir * _jumpDistance;
            this.MoveTowards(transform, jump, _fieldSize);
        }
    }
}
