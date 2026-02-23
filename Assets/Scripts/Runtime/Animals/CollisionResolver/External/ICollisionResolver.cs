using System;
using ZooWorld.Animals;

namespace ZooWorld.CollisionResolver
{
    public interface ICollisionResolver
    {
        event Action<HitData> OnCollision;

        void Resolve(IAnimal a, IAnimal b);
    }
}
