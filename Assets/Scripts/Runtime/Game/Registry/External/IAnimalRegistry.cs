using UniRx;
using ZooWorld.Animals;

namespace ZooWorld.Game
{
    public interface IAnimalRegistry
    {
        IReadOnlyReactiveProperty<int> DeadPreyCount { get; }
        IReadOnlyReactiveProperty<int> DeadPredatorCount { get; }

        void RegisterAlive(IAnimal animal);
        void UnregisterAndCountDeath(IAnimal animal);
    }
}
