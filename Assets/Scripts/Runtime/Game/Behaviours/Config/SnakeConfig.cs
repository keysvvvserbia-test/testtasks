using UnityEngine;
using ZooWorld.Animals.Movement;

namespace ZooWorld.Game.Behaviours.Config
{
    [CreateAssetMenu(menuName = "ZooWorld/Animals/Snake", fileName = "Snake")]
    public sealed class SnakeConfig : AnimalConfig
    {
        [Header("Linear movement")]
        [SerializeField] private float _unitsPerSecond = 2f;
        [SerializeField] private float _directionChangeInterval = 2f;

        public override IMovementStrategy CreateMovementStrategy(Vector2 fieldSize)
        {
            return new LinearMovementStrategy(_unitsPerSecond, _directionChangeInterval, fieldSize);
        }
    }
}

