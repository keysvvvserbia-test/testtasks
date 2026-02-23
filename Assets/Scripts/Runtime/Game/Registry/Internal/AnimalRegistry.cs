using System.Collections.Generic;
using UniRx;
using ZooWorld.Animals;
using ZooWorld.Foundation;

namespace ZooWorld.Game
{
    public sealed class AnimalRegistry : IAnimalRegistry
    {
        private readonly HashSet<IAnimal> _alive = new();
        private readonly ReactiveProperty<int> _deadPreyCount = new(0);
        private readonly ReactiveProperty<int> _deadPredatorCount = new(0);
        
        public IReadOnlyReactiveProperty<int> DeadPreyCount => _deadPreyCount;
        public IReadOnlyReactiveProperty<int> DeadPredatorCount => _deadPredatorCount;

        public void RegisterAlive(IAnimal animal)
        {
            if (!_alive.Add(animal))
                throw new System.Exception($"Duplicate animal {animal.GetHashCode()}");
        }

        public void UnregisterAndCountDeath(IAnimal animal)
        {
            if (!_alive.Remove(animal)) return;

            switch (animal.Diet)
            {
                case DietType.Prey:
                    _deadPreyCount.Value++;
                    break;
                case DietType.Predator:
                    _deadPredatorCount.Value++;
                    break;
            }
        }
    }
}
