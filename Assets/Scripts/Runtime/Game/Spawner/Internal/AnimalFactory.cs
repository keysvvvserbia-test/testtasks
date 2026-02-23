using UnityEngine;
using ZooWorld.Foundation;
using ZooWorld.Game.Behaviours;

namespace ZooWorld.Game
{
    public sealed class AnimalFactory : BasePoolFactory<AnimalBehaviour>
    {
        public AnimalFactory(Transform root) : base(root)
        {
        }
    }
}
