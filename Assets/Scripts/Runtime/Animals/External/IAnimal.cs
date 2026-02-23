using UnityEngine;

namespace ZooWorld.Animals
{
    public interface IAnimal
    {
        DietType Diet { get; }
        bool IsAlive { get; }
        Transform Transform { get; }

        void Die();
        void Kill();
        void Collision();
    }
}
