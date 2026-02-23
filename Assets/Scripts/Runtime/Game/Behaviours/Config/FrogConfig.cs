using UnityEngine;
using ZooWorld.Animals.Movement;
using ZooWorld.Foundation;
using ZooWorld.Game.Behaviours;

namespace ZooWorld.Game.Behaviours.Config
{
    /// <summary>
    /// Concrete configuration for Frog (prey that moves by jumps).
    /// </summary>
    [CreateAssetMenu(menuName = "ZooWorld/Animals/Frog", fileName = "Frog")]
    public sealed class FrogConfig : AnimalConfig
    {
        [Header("Jump movement")]
        [SerializeField] private float _jumpIntervalSeconds = 1.5f;
        [SerializeField] private float _jumpDistance = 2f;

        public override IMovementStrategy CreateMovementStrategy()
        {
            return new JumpMovementStrategy(_jumpIntervalSeconds, _jumpDistance);
        }
    }
}

