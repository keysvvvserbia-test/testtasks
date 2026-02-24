using Zenject;

namespace ZooWorld.Game
{
    public sealed class GameBootstrap : IInitializable
    {
        private readonly IAnimalSpawner _spawner;

        [Inject]
        public GameBootstrap(IAnimalSpawner spawner)
        {
            _spawner = spawner;
        }

        public void Initialize()
        {
            _spawner.StartSpawning();
        }
    }
}
