using UnityEngine;
using ZooWorld.Animals;
using ZooWorld.Animals.Movement;

namespace ZooWorld.Game.Behaviours.Config
{
    public abstract class AnimalConfig : ScriptableObject
    {
        [SerializeField] private DietType _diet = DietType.Prey;
        [SerializeField] private AnimalBehaviour _original;

        public string Id => name;
        public DietType Diet => _diet;
        public AnimalBehaviour Original => _original;

        public abstract IMovementStrategy CreateMovementStrategy(Vector2 fieldSize);
    }
}
