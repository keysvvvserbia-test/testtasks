using UnityEngine;
using ZooWorld.Animals.Movement;

namespace ZooWorld.Game.Behaviours.Config
{
    [CreateAssetMenu(menuName = "ZooWorld/Animals/Frog", fileName = "Frog")]
    public sealed class FrogConfig : AnimalConfig
    {
        [Header("Jump movement")]
        [SerializeField] private float _jumpIntervalSeconds = 1.5f;
        [SerializeField] private float _jumpDistance = 2f;

        public override IMovementStrategy CreateMovementStrategy(Vector2 fieldSize)
        {
            return new JumpMovementStrategy(_jumpIntervalSeconds, _jumpDistance, fieldSize);
        }
    }
}

