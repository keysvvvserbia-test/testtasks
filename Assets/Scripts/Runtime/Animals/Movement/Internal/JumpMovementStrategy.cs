using UnityEngine;
using ZooWorld.Foundation;

namespace ZooWorld.Animals.Movement
{
    public sealed class JumpMovementStrategy : IMovementStrategy
    {
        private readonly float _intervalSeconds;
        private readonly float _jumpDistance;

        private float _timer;

        public JumpMovementStrategy(float intervalSeconds, float jumpDistance)
        {
            _intervalSeconds = intervalSeconds;
            _jumpDistance = jumpDistance;
        }

        public void Tick(IAnimal animal, float deltaTime)
        {
            if (!animal.IsAlive)
                return;

            _timer += deltaTime;
            if (!(_timer >= _intervalSeconds))
                return;

            _timer = 0f;
            var x = Random.Range(-1f, 1f);
            var z = Random.Range(-1f, 1f);
            var dir = new Vector3(x, 0f, z);

            if (dir.sqrMagnitude < 0.01f)
            {
                dir = Vector3.forward;
            }

            dir.Normalize();

            var jump = dir * _jumpDistance;
            this.MoveTowards(animal.Transform, jump);
        }
    }
}
