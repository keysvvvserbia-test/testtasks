using System;
using ZooWorld.Animals;

namespace ZooWorld.CollisionResolver
{
    public sealed class CollisionResolver : ICollisionResolver
    {
        public event Action<HitData> OnCollision;

        public void Resolve(IAnimal a, IAnimal b)
        {
            if (!a.IsAlive || !b.IsAlive) return;

            var dietA = a.Diet;
            var dietB = b.Diet;

            if (dietA == DietType.Predator)
            {
                b.Die();
                a.Kill();
                OnCollision?.Invoke(new HitData(a, b));
                return;
            }

            if (dietB == DietType.Predator)
            {
                a.Die();
                b.Kill();
                OnCollision?.Invoke(new HitData(b, a));
                return;
            }
            
            a.Collision();
            b.Collision();
        }
    }
}
