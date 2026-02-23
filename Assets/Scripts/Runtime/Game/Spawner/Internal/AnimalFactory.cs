using UnityEngine;
using ZooWorld.Foundation;
using ZooWorld.Animals;

namespace ZooWorld.Game
{
    public sealed class AnimalFactory : BasePoolFactory<AnimalBehaviour>
    {
        public AnimalFactory(Transform root) : base(root)
        {
        }
    }
}
