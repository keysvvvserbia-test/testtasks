using UnityEngine;
using ZooWorld.Animals.Movement;

namespace ZooWorld.Animals
{
    public abstract class AnimalConfig : ScriptableObject
    {
        [SerializeField] private DietType _diet = DietType.Prey;
        [SerializeField] private AnimalBehaviour _original;

        public string Id => name;
        public DietType Diet => _diet;
        public AnimalBehaviour Original => _original;
        
        public abstract IMovementStrategy CreateMovementStrategy();
    }
}

