using Zenject;

namespace ZooWorld.Game
{
    /// <summary>
    /// Starts the game loop (spawning) when the scene loads.
    /// </summary>
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
