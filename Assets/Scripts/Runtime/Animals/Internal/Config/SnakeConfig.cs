using UnityEngine;
using ZooWorld.Animals.Movement;
using ZooWorld.Foundation;

namespace ZooWorld.Animals.Config
{
    /// <summary>
    /// Concrete configuration for Snake (predator that moves linearly).
    /// </summary>
    [CreateAssetMenu(menuName = "ZooWorld/Animals/Snake", fileName = "Snake")]
    public sealed class SnakeConfig : AnimalConfig
    {
        [Header("Linear movement")]
        [SerializeField] private float _unitsPerSecond = 2f;
        [SerializeField] private float _directionChangeInterval = 2f;

        public override IMovementStrategy CreateMovementStrategy()
        {
            return new LinearMovementStrategy(_unitsPerSecond, _directionChangeInterval);
        }
    }
}

